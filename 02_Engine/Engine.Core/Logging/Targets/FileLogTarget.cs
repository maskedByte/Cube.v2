using System.Text;

namespace Engine.Logging.Targets;

/// <summary>
/// Log target for logging to a file
/// </summary>
public sealed class FileLogTarget : ILogTarget
{
    private readonly string _filePath;

    public FileLogTarget(string filePath)
    {
        _filePath = filePath;

        if (!File.Exists(_filePath))
        {
            File.Create(_filePath).Dispose();
        }
    }

    /// <inheritdoc />
    public async Task LogMessageAsync(LogEntry logEntry)
    {
        try
        {
            await using var writer = new StreamWriter(_filePath, true, Encoding.UTF8);
            await writer.WriteLineAsync(logEntry.GetFormattedLogEntry());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while writing to log file: {ex}");
        }
    }

    /// <inheritdoc />
    public void Dispose()
    {
    }
}
