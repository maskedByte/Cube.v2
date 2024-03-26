using System.Runtime.InteropServices;

namespace Engine.Core.Files;

public static class FileExtension
{
    private const int RetryCount = 10;
    private const int TimeIntervalBetweenTries = 100;

    public static MemoryStream AsStream(this string filePath, FileAccess fileAccess)
    {
        var tries = 0;
        while (true)
        {
            try
            {
                using var fileStream = File.Open(filePath, FileMode.Open, fileAccess, FileShare.None);
                var memoryStream = new MemoryStream();
                fileStream.CopyTo(memoryStream);
                fileStream.Close();
                return memoryStream;
            }
            catch (IOException e)
            {
                if (!IsFileLocked(e))
                {
                    throw;
                }

                if (++tries > RetryCount)
                {
                    throw new IOException("The file is locked too long: " + e.Message, e);
                }

                Thread.Sleep(TimeIntervalBetweenTries);
            }
        }
    }

    public static FileStream AsFileStream(this string filePath, FileMode fileMode, FileAccess fileAccess)
    {
        var tries = 0;
        while (true)
        {
            try
            {
                return File.Open(filePath, fileMode, fileAccess, FileShare.None);
            }
            catch (IOException e)
            {
                if (!IsFileLocked(e))
                {
                    throw;
                }

                if (++tries > RetryCount)
                {
                    throw new IOException("The file is locked too long: " + e.Message, e);
                }

                Thread.Sleep(TimeIntervalBetweenTries);
            }
        }
    }

    private static bool IsFileLocked(Exception exception)
    {
        var errorCode = Marshal.GetHRForException(exception) & ((1 << 16) - 1);
        return errorCode == 32 || errorCode == 33;
    }
}
