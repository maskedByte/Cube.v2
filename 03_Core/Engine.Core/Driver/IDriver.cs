using Engine.Core.Driver.Graphics;
using Engine.Core.Driver.Graphics.Buffers;
using Engine.Core.Driver.Input;
using Engine.Core.Driver.Window;
using Engine.Core.Math.Base;

namespace Engine.Core.Driver;

/// <summary>
///     Base interface for all graphics drivers.
/// </summary>
public interface IDriver
{
    /// <summary>
    ///     The graphics api reference
    /// </summary>
    /// <returns>Return the graphics api reference</returns>
    IGraphicsApi GetApi();

    /// <summary>
    ///     Create a new window
    /// </summary>
    /// <param name="width">The width of the window</param>
    /// <param name="height">The height of the window</param>
    /// <param name="vSync">Sets the vSync</param>
    /// <param name="fullscreen">Sets if the window should be fullscreen</param>
    /// <param name="resizeAble">Sets if the window should be resizeable</param>
    /// <param name="showStats">Sets if stats should be shown</param>
    IWindow CreateWindow(
        int width,
        int height,
        bool vSync,
        bool fullscreen = false,
        bool resizeAble = false,
        bool showStats = false
    );

    /// <summary>
    ///     Sets the clear color
    /// </summary>
    /// <param name="color">The color to set, <see cref="Color" /></param>
    void SetClearColor(Color color);

    /// <summary>
    ///     Close graphics context & Window
    /// </summary>
    void Close();

    /// <summary>
    ///     Clear screen
    /// </summary>
    void Clear(ClearBufferFlag clearBufferFlag = ClearBufferFlag.AllBufferBits);

    /// <summary>
    ///     Handle incoming window events, has to be called in main loop
    /// </summary>
    void HandleEvents();

    /// <summary>
    ///     Flip Front-/Backbuffer
    /// </summary>
    void Swap();

    /// <summary>
    ///     Return input handler from driver
    /// </summary>
    /// <returns>Returns the input handler</returns>
    IInput GetInput();

    /// <summary>
    ///     Render indexed triangles to actual frame buffer
    /// </summary>
    /// <param name="bindable">A <see cref="IBufferArray" /> to render</param>
    /// <param name="drawMode">Set draw mode, <see cref="DrawMode" /></param>
    /// <param name="indexCount">Set count of indices to render</param>
    void DrawIndexed(IBufferArray bindable, DrawMode drawMode, int indexCount);
}
