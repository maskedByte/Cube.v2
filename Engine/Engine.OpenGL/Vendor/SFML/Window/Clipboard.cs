using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using SFML.System;

namespace Engine.OpenGL.Vendor.SFML.Window;

/// <summary>
/// Clipboard provides an interface for getting and setting the contents of the system clipboard.
/// </summary>
internal class Clipboard
{
    /// <summary>
    /// The contents of the Clipboard as a UTF-32 string
    /// </summary>
    public static string Contents
    {
        get
        {
            var source = sfClipboard_getUnicodeString();

            uint length = 0;
            unsafe
            {
                for (var ptr = (uint*)source.ToPointer(); *ptr != 0; ++ptr) length++;
            }

            var sourceBytes = new byte[length * 4];
            Marshal.Copy(source, sourceBytes, 0, sourceBytes.Length);

            return Encoding.UTF32.GetString(sourceBytes);
        }
        set
        {
            var utf32 = Encoding.UTF32.GetBytes(value + '\0');

            unsafe
            {
                fixed (byte* ptr = utf32)
                {
                    sfClipboard_setUnicodeString((IntPtr)ptr);
                }
            }
        }
    }

    [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl)]
    [SuppressUnmanagedCodeSecurity]
    private static extern IntPtr sfClipboard_getUnicodeString();

    [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl)]
    [SuppressUnmanagedCodeSecurity]
    private static extern void sfClipboard_setUnicodeString(IntPtr ptr);
}
