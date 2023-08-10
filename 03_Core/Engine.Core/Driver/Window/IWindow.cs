namespace Engine.Core.Driver.Window;

/// <summary>
///     Interface for window.
/// </summary>
public interface IWindow
{
    /// <summary>
    ///     Set the cursor visibility
    /// </summary>
    bool CursorVisible { get; set; }

    /// <summary>
    ///     Set if the cursor should be grabbed
    /// </summary>
    bool CursorGrabbed { get; set; }

    /// <summary>
    ///     Forces the window to close
    /// </summary>
    void Terminate();

    /// <summary>
    ///     Returns if the window should be closed
    /// </summary>
    /// <returns>Returns true if the window should be closed</returns>
    bool WindowTerminated();

    /// <summary>
    ///     Set actual window focus
    /// </summary>
    void RequestFocus();

    /// <summary>
    ///     Set the window size
    /// </summary>
    /// <param name="width">New width of the window</param>
    /// <param name="height">New height of the window</param>
    void SetSize(int width, int height);

    /// <summary>
    ///     Set the window position
    /// </summary>
    /// <param name="x">The new x position</param>
    /// <param name="y">The new y position</param>
    void SetPosition(int x, int y);

    /// <summary>
    ///     Set the window title
    /// </summary>
    /// <param name="title">The new title</param>
    void SetTitle(string title);

    /// <summary>
    ///     Set the windows vSync
    /// </summary>
    /// <param name="vSync">State of vSync</param>
    void SetVSync(bool vSync);

    /// <summary>
    ///     Set if the window should be visible
    /// </summary>
    /// <param name="visible">State of visibility</param>
    void SetVisible(bool visible);

    /// <summary>
    ///     Set the window fullscreen, works only after window recreation
    /// </summary>
    /// <param name="fullscreen">State of fullscreen</param>
    void SetFullscreen(bool fullscreen);

    /// <summary>
    ///     Draw the window
    /// </summary>
    void Display();

    /// <summary>
    ///     Close the window
    /// </summary>
    void Close();

    /// <summary>
    ///     Handle incoming window events
    /// </summary>
    void HandleEvents();
}
