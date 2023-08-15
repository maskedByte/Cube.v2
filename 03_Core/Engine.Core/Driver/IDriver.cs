﻿using Engine.Core.Driver.Input;
using Engine.Core.Driver.Window;

namespace Engine.Core.Driver;

/// <summary>
///     Base interface for all graphics drivers.
/// </summary>
public interface IDriver
{
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
    ///     Return the current window
    /// </summary>
    /// <returns>Returns an instance of <see cref="IWindow" /></returns>
    IWindow? GetWindow();

    /// <summary>
    ///     Get the current context
    /// </summary>
    /// <returns>Returns an instance of <see cref="IContext" /></returns>
    IContext? GetContext();
}
