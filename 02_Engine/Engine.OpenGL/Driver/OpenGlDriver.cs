using Engine.Core.Driver;
using Engine.Core.Driver.Input;
using Engine.Core.Driver.Window;
using Engine.Core.Logging;
using Engine.OpenGL.GraphicsApi;
using Engine.OpenGL.Vendor.OpenGL.Core;

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

namespace Engine.OpenGL.Driver;

/// <summary>
///     OpenGL driver.
///     Implements <see cref="IDriver" /> to use OpenGL 4.5+ as graphics driver.
/// </summary>
public sealed class OpenGlDriver : IDriver
{
    private readonly Input _input;
    private IContext? _context;

    /// <summary>
    ///     Gets the current window.
    /// </summary>
    public IWindow? CurrentWindow { get; private set; }

    /// <summary>
    ///     Default parameterless constructor.
    /// </summary>
    public OpenGlDriver()
    {
        _context = null;
        CurrentWindow = null;
        _input = new Input() ?? throw new NullReferenceException(nameof(_input));
    }

    /// <inheritdoc />
    public IWindow CreateWindow(
        int width,
        int height,
        bool vSync,
        bool fullscreen,
        bool resizeAble = false,
        bool showStats = false
    )
    {
        if (CurrentWindow != null)
        {
            Log.LogMessageAsync("Window already created.", LogLevel.Warning, this);
            return CurrentWindow;
        }

        CurrentWindow = new Window(width, height, vSync, fullscreen, resizeAble);

        if (CurrentWindow == null)
        {
            throw new NullReferenceException(nameof(CurrentWindow));
        }

        _context = new Context(this);
        _context.Initialize();

        if (showStats)
        {
            ShowOpenGlExtensions();
        }

        ((Window)CurrentWindow).SetInput(_input);
        Keyboard.SetInput(_input);
        Mouse.SetInput(_input);

        return CurrentWindow;
    }

    /// <inheritdoc />
    public void Close()
    {
        if (CurrentWindow == null)
        {
            Log.LogMessageAsync("Window not created.", LogLevel.Warning, this);
        }
    }

    /// <inheritdoc />
    public void Clear(ClearBufferFlag clearBufferFlag = ClearBufferFlag.AllBufferBits)
    {
        var clearMask = ClearBufferMask.None;

        if (clearBufferFlag.HasFlag(ClearBufferFlag.ColorBufferBit))
        {
            clearMask = ClearBufferMask.ColorBufferBit;
        }

        if (clearBufferFlag.HasFlag(ClearBufferFlag.DepthBufferBit))
        {
            clearMask |= ClearBufferMask.DepthBufferBit;
        }

        if (clearBufferFlag.HasFlag(ClearBufferFlag.StencilBufferBit))
        {
            clearMask |= ClearBufferMask.StencilBufferBit;
        }

        if (clearBufferFlag.HasFlag(ClearBufferFlag.AccumBufferBit))
        {
            clearMask |= ClearBufferMask.AccumBufferBit;
        }

        Gl.Clear(clearMask);

        _input.Reset();
    }

    /// <inheritdoc />
    public void HandleEvents() => CurrentWindow?.HandleEvents();

    /// <inheritdoc />
    public void Swap()
    {
        CurrentWindow?.Display();
        Time.Instance.Update();
    }

    /// <inheritdoc />
    public IInput GetInput() => _input;

    /// <inheritdoc />
    public IWindow? GetWindow() => CurrentWindow;

    /// <inheritdoc />
    public IContext? GetContext() => _context;

    private void ShowOpenGlExtensions()
    {
        if (_context == null || !_context.IsInitialized)
        {
            return;
        }

        Console.WriteLine(_context.GetVersion());
        Console.WriteLine(_context.GetVendor());
        Console.WriteLine(_context.GetRenderer());
        Console.WriteLine(_context.GetShadingLanguageVersion());
        Console.WriteLine("Extensions:");

        foreach (var extension in _context.GetSupportedExtension())
        {
            Console.WriteLine($"\t{extension}");
        }
    }
}
