using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using SFML;
using SFML.System;

namespace Engine.OpenGL.Vendor.SFML.Window;

////////////////////////////////////////////////////////////
/// <summary>
/// Enumeration of window creation styles
/// </summary>
////////////////////////////////////////////////////////////
[Flags]
public enum Styles
{
    /// <summary>No border / title bar (this flag and all others are mutually exclusive)</summary>
    None = 0,

    /// <summary>Title bar + fixed border</summary>
    Titlebar = 1 << 0,

    /// <summary>Titlebar + resizable border + maximize button</summary>
    Resize = 1 << 1,

    /// <summary>Titlebar + close button</summary>
    Close = 1 << 2,

    /// <summary>Fullscreen mode (this flag and all others are mutually exclusive))</summary>
    Fullscreen = 1 << 3,

    /// <summary>Default window style (titlebar + resize + close)</summary>
    Default = Titlebar | Resize | Close
}

////////////////////////////////////////////////////////////
/// <summary>
/// Window is a rendering window ; it can create a new window
/// or connect to an existing one
/// </summary>
////////////////////////////////////////////////////////////
public class Window : ObjectBase
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Create the window with default style and creation settings
    /// </summary>
    /// <param name="mode">Video mode to use</param>
    /// <param name="title">Title of the window</param>
    ////////////////////////////////////////////////////////////
    public Window(VideoMode mode, string title) :
        this(mode, title, Styles.Default, new ContextSettings(0, 0))
    {
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Create the window with default creation settings
    /// </summary>
    /// <param name="mode">Video mode to use</param>
    /// <param name="title">Title of the window</param>
    /// <param name="style">Window style (Resize | Close by default)</param>
    ////////////////////////////////////////////////////////////
    public Window(VideoMode mode, string title, Styles style) :
        this(mode, title, style, new ContextSettings(0, 0))
    {
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Create the window
    /// </summary>
    /// <param name="mode">Video mode to use</param>
    /// <param name="title">Title of the window</param>
    /// <param name="style">Window style (Resize | Close by default)</param>
    /// <param name="settings">Creation parameters</param>
    ////////////////////////////////////////////////////////////
    public Window(VideoMode mode, string title, Styles style, ContextSettings settings) :
        base(IntPtr.Zero)
    {
        // Copy the title to a null-terminated UTF-32 byte array
        var titleAsUtf32 = Encoding.UTF32.GetBytes(title + '\0');

        unsafe
        {
            fixed (byte* titlePtr = titleAsUtf32)
            {
                CPointer = sfWindow_createUnicode(mode, (IntPtr)titlePtr, style, ref settings);
            }
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Create the window from an existing control with default creation settings
    /// </summary>
    /// <param name="handle">Platform-specific handle of the control</param>
    ////////////////////////////////////////////////////////////
    public Window(IntPtr handle) :
        this(handle, new ContextSettings(0, 0))
    {
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Create the window from an existing control
    /// </summary>
    /// <param name="handle">Platform-specific handle of the control</param>
    /// <param name="settings">Creation parameters</param>
    ////////////////////////////////////////////////////////////
    public Window(IntPtr handle, ContextSettings settings) :
        base(sfWindow_createFromHandle(handle, ref settings))
    {
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Tell whether or not the window is opened (ie. has been created).
    /// Note that a hidden window (Show(false))
    /// will still return true
    /// </summary>
    /// <returns>True if the window is opened</returns>
    ////////////////////////////////////////////////////////////
    public virtual bool IsOpen
    {
        get { return sfWindow_isOpen(CPointer); }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Close (destroy) the window.
    /// The Window instance remains valid and you can call
    /// Create to recreate the window
    /// </summary>
    ////////////////////////////////////////////////////////////
    public virtual void Close()
    {
        sfWindow_close(CPointer);
        Destroy(false);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Display the window on screen
    /// </summary>
    ////////////////////////////////////////////////////////////
    public virtual void Display()
    {
        sfWindow_display(CPointer);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Creation settings of the window
    /// </summary>
    ////////////////////////////////////////////////////////////
    public virtual ContextSettings Settings
    {
        get { return sfWindow_getSettings(CPointer); }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Position of the window
    /// </summary>
    ////////////////////////////////////////////////////////////
    public virtual Vector2i Position
    {
        get { return sfWindow_getPosition(CPointer); }
        set { sfWindow_setPosition(CPointer, value); }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Size of the rendering region of the window
    /// </summary>
    ////////////////////////////////////////////////////////////
    public virtual Vector2u Size
    {
        get { return sfWindow_getSize(CPointer); }
        set { sfWindow_setSize(CPointer, value); }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Change the title of the window
    /// </summary>
    /// <param name="title">New title</param>
    ////////////////////////////////////////////////////////////
    public virtual void SetTitle(string title)
    {
        // Copy the title to a null-terminated UTF-32 byte array
        var titleAsUtf32 = Encoding.UTF32.GetBytes(title + '\0');

        unsafe
        {
            fixed (byte* titlePtr = titleAsUtf32)
            {
                sfWindow_setUnicodeTitle(CPointer, (IntPtr)titlePtr);
            }
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Change the window's icon
    /// </summary>
    /// <param name="width">Icon's width, in pixels</param>
    /// <param name="height">Icon's height, in pixels</param>
    /// <param name="pixels">Array of pixels, format must be RGBA 32 bits</param>
    ////////////////////////////////////////////////////////////
    public virtual void SetIcon(uint width, uint height, byte[] pixels)
    {
        unsafe
        {
            fixed (byte* pixelsPtr = pixels)
            {
                sfWindow_setIcon(CPointer, width, height, pixelsPtr);
            }
        }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Show or hide the window
    /// </summary>
    /// <param name="visible">True to show the window, false to hide it</param>
    ////////////////////////////////////////////////////////////
    public virtual void SetVisible(bool visible)
    {
        sfWindow_setVisible(CPointer, visible);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Show or hide the mouse cursor
    /// </summary>
    /// <param name="show">True to show, false to hide</param>
    ////////////////////////////////////////////////////////////
    public virtual void SetMouseCursorVisible(bool show)
    {
        sfWindow_setMouseCursorVisible(CPointer, show);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Grab or release the mouse cursor
    /// </summary>
    /// <param name="grabbed">True to grab, false to release</param>
    ///
    /// <remarks>
    /// If set, grabs the mouse cursor inside this window's client
    /// area so it may no longer be moved outside its bounds.
    /// Note that grabbing is only active while the window has
    /// focus and calling this function for fullscreen windows
    /// won't have any effect (fullscreen windows always grab the
    /// cursor).
    /// </remarks>
    ////////////////////////////////////////////////////////////
    public virtual void SetMouseCursorGrabbed(bool grabbed)
    {
        sfWindow_setMouseCursorGrabbed(CPointer, grabbed);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Set the displayed cursor to a native system cursor
    /// </summary>
    /// <param name="cursor">Native system cursor type to display</param>
    ////////////////////////////////////////////////////////////
    public virtual void SetMouseCursor(Cursor cursor)
    {
        sfWindow_setMouseCursor(CPointer, cursor.CPointer);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Enable / disable vertical synchronization
    /// </summary>
    /// <param name="enable">True to enable v-sync, false to deactivate</param>
    ////////////////////////////////////////////////////////////
    public virtual void SetVerticalSyncEnabled(bool enable)
    {
        sfWindow_setVerticalSyncEnabled(CPointer, enable);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Enable or disable automatic key-repeat.
    /// Automatic key-repeat is enabled by default
    /// </summary>
    /// <param name="enable">True to enable, false to disable</param>
    ////////////////////////////////////////////////////////////
    public virtual void SetKeyRepeatEnabled(bool enable)
    {
        sfWindow_setKeyRepeatEnabled(CPointer, enable);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Activate the window as the current target
    /// for rendering
    /// </summary>
    /// <returns>True if operation was successful, false otherwise</returns>
    ////////////////////////////////////////////////////////////
    public virtual bool SetActive()
    {
        return SetActive(true);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Activate of deactivate the window as the current target
    /// for rendering
    /// </summary>
    /// <param name="active">True to activate, false to deactivate (true by default)</param>
    /// <returns>True if operation was successful, false otherwise</returns>
    ////////////////////////////////////////////////////////////
    public virtual bool SetActive(bool active)
    {
        return sfWindow_setActive(CPointer, active);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Limit the framerate to a maximum fixed frequency
    /// </summary>
    /// <param name="limit">Framerate limit, in frames per seconds (use 0 to disable limit)</param>
    ////////////////////////////////////////////////////////////
    public virtual void SetFramerateLimit(uint limit)
    {
        sfWindow_setFramerateLimit(CPointer, limit);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Change the joystick threshold, ie. the value below which
    /// no move event will be generated
    /// </summary>
    /// <param name="threshold">New threshold, in range [0, 100]</param>
    ////////////////////////////////////////////////////////////
    public virtual void SetJoystickThreshold(float threshold)
    {
        sfWindow_setJoystickThreshold(CPointer, threshold);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// OS-specific handle of the window
    /// </summary>
    ////////////////////////////////////////////////////////////
    public virtual IntPtr SystemHandle
    {
        get { return sfWindow_getSystemHandle(CPointer); }
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Call the event handlers for each pending event
    /// </summary>
    ////////////////////////////////////////////////////////////
    public bool PollEvents(out Event eventToFill)
    {
        return PollEvent(out eventToFill);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Request the current window to be made the active
    /// foreground window
    /// </summary>
    ////////////////////////////////////////////////////////////
    public virtual void RequestFocus()
    {
        sfWindow_requestFocus(CPointer);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Check whether the window has the input focus
    /// </summary>
    /// <returns>True if the window has focus, false otherwise</returns>
    ////////////////////////////////////////////////////////////
    public virtual bool HasFocus()
    {
        return sfWindow_hasFocus(CPointer);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Provide a string describing the object
    /// </summary>
    /// <returns>String description of the object</returns>
    ////////////////////////////////////////////////////////////
    public override string ToString()
    {
        return "[Window]" +
               " Size(" + Size + ")" +
               " Position(" + Position + ")" +
               " Settings(" + Settings + ")";
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Constructor for derived classes
    /// </summary>
    /// <param name="cPointer">Pointer to the internal object in the C API</param>
    /// <param name="dummy">Internal hack :)</param>
    ////////////////////////////////////////////////////////////
    protected Window(IntPtr cPointer, int dummy) :
        base(cPointer)
    {
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Internal function to get the next event (non-blocking)
    /// </summary>
    /// <param name="eventToFill">Variable to fill with the raw pointer to the event structure</param>
    /// <returns>True if there was an event, false otherwise</returns>
    ////////////////////////////////////////////////////////////
    protected virtual bool PollEvent(out Event eventToFill)
    {
        return sfWindow_pollEvent(CPointer, out eventToFill);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Internal function to get the next event (blocking)
    /// </summary>
    /// <param name="eventToFill">Variable to fill with the raw pointer to the event structure</param>
    /// <returns>False if any error occured</returns>
    ////////////////////////////////////////////////////////////
    protected virtual bool WaitEvent(out Event eventToFill)
    {
        return sfWindow_waitEvent(CPointer, out eventToFill);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Internal function to get the mouse position relative to the window.
    /// This function is protected because it is called by another class of
    /// another module, it is not meant to be called by users.
    /// </summary>
    /// <returns>Relative mouse position</returns>
    ////////////////////////////////////////////////////////////
    protected internal virtual Vector2i InternalGetMousePosition()
    {
        return sfMouse_getPosition(CPointer);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Internal function to set the mouse position relative to the window.
    /// This function is protected because it is called by another class of
    /// another module, it is not meant to be called by users.
    /// </summary>
    /// <param name="position">Relative mouse position</param>
    ////////////////////////////////////////////////////////////
    protected internal virtual void InternalSetMousePosition(Vector2i position)
    {
        sfMouse_setPosition(position, CPointer);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Internal function to get the touch position relative to the window.
    /// This function is protected because it is called by another class of
    /// another module, it is not meant to be called by users.
    /// </summary>
    /// <param name="finger">Finger index</param>
    /// <returns>Relative touch position</returns>
    ////////////////////////////////////////////////////////////
    protected internal virtual Vector2i InternalGetTouchPosition(uint finger)
    {
        return sfTouch_getPosition(finger, CPointer);
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Handle the destruction of the object
    /// </summary>
    /// <param name="disposing">Is the GC disposing the object, or is it an explicit call ?</param>
    ////////////////////////////////////////////////////////////
    protected override void Destroy(bool disposing)
    {
        sfWindow_destroy(CPointer);
    }


    #region Imports

    [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl)]
    [SuppressUnmanagedCodeSecurity]
    private static extern IntPtr sfWindow_create(VideoMode mode, string title, Styles style,
        ref ContextSettings @params);

    [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl)]
    [SuppressUnmanagedCodeSecurity]
    private static extern IntPtr sfWindow_createUnicode(VideoMode mode, IntPtr title, Styles style,
        ref ContextSettings @params);

    [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl)]
    [SuppressUnmanagedCodeSecurity]
    private static extern IntPtr sfWindow_createFromHandle(IntPtr handle, ref ContextSettings @params);

    [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl)]
    [SuppressUnmanagedCodeSecurity]
    private static extern void sfWindow_destroy(IntPtr cPointer);

    [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl)]
    [SuppressUnmanagedCodeSecurity]
    private static extern bool sfWindow_isOpen(IntPtr cPointer);

    [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl)]
    [SuppressUnmanagedCodeSecurity]
    private static extern void sfWindow_close(IntPtr cPointer);

    [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl)]
    [SuppressUnmanagedCodeSecurity]
    private static extern bool sfWindow_pollEvent(IntPtr cPointer, out Event evt);

    [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl)]
    [SuppressUnmanagedCodeSecurity]
    private static extern bool sfWindow_waitEvent(IntPtr cPointer, out Event evt);

    [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl)]
    [SuppressUnmanagedCodeSecurity]
    private static extern void sfWindow_display(IntPtr cPointer);

    [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl)]
    [SuppressUnmanagedCodeSecurity]
    private static extern ContextSettings sfWindow_getSettings(IntPtr cPointer);

    [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl)]
    [SuppressUnmanagedCodeSecurity]
    private static extern Vector2i sfWindow_getPosition(IntPtr cPointer);

    [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl)]
    [SuppressUnmanagedCodeSecurity]
    private static extern void sfWindow_setPosition(IntPtr cPointer, Vector2i position);

    [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl)]
    [SuppressUnmanagedCodeSecurity]
    private static extern Vector2u sfWindow_getSize(IntPtr cPointer);

    [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl)]
    [SuppressUnmanagedCodeSecurity]
    private static extern void sfWindow_setSize(IntPtr cPointer, Vector2u size);

    [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl)]
    [SuppressUnmanagedCodeSecurity]
    private static extern void sfWindow_setTitle(IntPtr cPointer, string title);

    [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl)]
    [SuppressUnmanagedCodeSecurity]
    private static extern void sfWindow_setUnicodeTitle(IntPtr cPointer, IntPtr title);

    [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl)]
    [SuppressUnmanagedCodeSecurity]
    private static extern unsafe void sfWindow_setIcon(IntPtr cPointer, uint width, uint height, byte* pixels);

    [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl)]
    [SuppressUnmanagedCodeSecurity]
    private static extern void sfWindow_setVisible(IntPtr cPointer, bool visible);

    [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl)]
    [SuppressUnmanagedCodeSecurity]
    private static extern void sfWindow_setMouseCursorVisible(IntPtr cPointer, bool show);

    [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl)]
    [SuppressUnmanagedCodeSecurity]
    private static extern void sfWindow_setMouseCursorGrabbed(IntPtr cPointer, bool grabbed);

    [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl)]
    [SuppressUnmanagedCodeSecurity]
    private static extern void sfWindow_setMouseCursor(IntPtr cPointer, IntPtr cursor);

    [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl)]
    [SuppressUnmanagedCodeSecurity]
    private static extern void sfWindow_setVerticalSyncEnabled(IntPtr cPointer, bool enable);

    [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl)]
    [SuppressUnmanagedCodeSecurity]
    private static extern void sfWindow_setKeyRepeatEnabled(IntPtr cPointer, bool enable);

    [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl)]
    [SuppressUnmanagedCodeSecurity]
    private static extern bool sfWindow_setActive(IntPtr cPointer, bool active);

    [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl)]
    [SuppressUnmanagedCodeSecurity]
    private static extern void sfWindow_setFramerateLimit(IntPtr cPointer, uint limit);

    [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl)]
    [SuppressUnmanagedCodeSecurity]
    private static extern uint sfWindow_getFrameTime(IntPtr cPointer);

    [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl)]
    [SuppressUnmanagedCodeSecurity]
    private static extern void sfWindow_setJoystickThreshold(IntPtr cPointer, float threshold);

    [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl)]
    [SuppressUnmanagedCodeSecurity]
    private static extern IntPtr sfWindow_getSystemHandle(IntPtr cPointer);

    [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl)]
    [SuppressUnmanagedCodeSecurity]
    private static extern void sfWindow_requestFocus(IntPtr cPointer);

    [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl)]
    [SuppressUnmanagedCodeSecurity]
    private static extern bool sfWindow_hasFocus(IntPtr cPointer);

    [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl)]
    [SuppressUnmanagedCodeSecurity]
    private static extern Vector2i sfMouse_getPosition(IntPtr cPointer);

    [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl)]
    [SuppressUnmanagedCodeSecurity]
    private static extern void sfMouse_setPosition(Vector2i position, IntPtr cPointer);

    [DllImport(CSFML.window, CallingConvention = CallingConvention.Cdecl)]
    [SuppressUnmanagedCodeSecurity]
    private static extern Vector2i sfTouch_getPosition(uint finger, IntPtr relativeTo);

    #endregion
}
