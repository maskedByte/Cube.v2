﻿using Engine.Driver.Input;
using Engine.Driver.Window;
using Engine.Math.Core;

namespace Engine.Driver;

/// <summary>
/// Base interface for all graphics drivers.
/// </summary>
public interface IDriver
{
    /// <summary>
    /// Create a new window
    /// </summary>
    /// <param name="width">The width of the window</param>
    /// <param name="height">The height of the window</param>
    /// <param name="vSync">Sets the vSync</param>
    /// <param name="showStats">Sets if stats should be shown</param>
    IWindow CreateWindow(int width, int height, bool vSync, bool showStats);

    /// <summary>
    /// Sets the clear color
    /// </summary>
    /// <param name="color">The color to set, <see cref="Color" /></param>
    void SetClearColor(Color color);

    /// <summary>
    /// Close graphics context & Window
    /// </summary>
    void Close();

    /// <summary>
    /// Clear screen
    /// </summary>
    void Clear(ClearBufferFlag clearBufferFlag = ClearBufferFlag.AllBufferBits);

    /// <summary>
    /// Handle incoming window events, has to be called in main loop
    /// </summary>
    void HandleEvents();

    /// <summary>
    /// Flip Front-/Backbuffer
    /// </summary>
    void Swap();

    /// <summary>
    /// Return input handler from driver
    /// </summary>
    /// <returns>Returns the input handler</returns>
    IInput GetInput();

    /// <summary>
    /// Render indexed triangles to actual frame buffer
    /// </summary>
    /// <param name="bindable">A <see cref="IBindable" /> to render</param>
    /// <param name="drawMode">Set draw mode, <see cref="DrawMode" /></param>
    /// <param name="indexCount">Set count of indices to render</param>
    void DrawIndexed(IBindable bindable, DrawMode drawMode, int indexCount);
}
