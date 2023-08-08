using Engine.Driver;
using Engine.Driver.Api;
using Engine.Driver.Input;
using Engine.Driver.Window;
using Engine.Exceptions;
using Engine.Logging;
using Engine.Math.Core;
using Engine.OpenGL.GraphicsApi;
using Engine.OpenGL.Vendor.OpenGL.Core;

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

namespace Engine.OpenGL.Driver;

/// <summary>
/// OpenGL driver.
/// Implements <see cref="IDriver" /> to use OpenGL 4.5+ as graphics driver.
/// </summary>
public sealed class OpenGlDriver : IDriver
{
    private static readonly Dictionary<DrawMode, BeginMode> DrawModeToBeginMode = new Dictionary<DrawMode, BeginMode>
    {
        { DrawMode.Points, BeginMode.Points },
        { DrawMode.Lines, BeginMode.Lines },
        { DrawMode.LineLoop, BeginMode.LineLoop },
        { DrawMode.LineStrip, BeginMode.LineStrip },
        { DrawMode.Triangles, BeginMode.Triangles },
        { DrawMode.TriangleStrip, BeginMode.TriangleStrip },
        { DrawMode.TriangleFan, BeginMode.TriangleFan },
        { DrawMode.Quads, BeginMode.Triangles }, // Adjust as needed
        { DrawMode.Polygon, BeginMode.Triangles } // Adjust as needed
    };

    private bool _isInitialized;
    private readonly Input _input;
    private IGraphicsApi? _graphicsApi;

    /// <summary>
    /// Gets the current window.
    /// </summary>
    public IWindow? CurrentWindow { get; private set; }

    /// <summary>
    /// Default parameterless constructor.
    /// </summary>
    public OpenGlDriver()
    {
        _graphicsApi = null;
        _isInitialized = false;
        CurrentWindow = null;
        _input = new Input() ?? throw new NullReferenceException(nameof(_input));
    }

    /// <inheritdoc />
    public IWindow CreateWindow(int width, int height, bool vSync, bool fullscreen, bool resizeAble = false,
        bool showStats = false)
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

        // Init openGl context
        Gl.PointSize(2f);
        Gl.Enable(EnableCap.DepthTest);

        Gl.Enable(EnableCap.CullFace);
        Gl.CullFace(CullFaceMode.Back);
        Gl.FrontFace(FrontFaceDirection.Cw);

        Gl.Enable(EnableCap.Blend);
        Gl.DepthFunc(DepthFunction.Less);
        Gl.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);

        _isInitialized = true;
        _graphicsApi = new OpenGlGraphicsApi();

        if (_graphicsApi == null)
        {
            throw new NullReferenceException(nameof(_graphicsApi));
        }

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
    public void SetClearColor(Color color)
    {
        if (!_isInitialized)
        {
            throw new ContextNotInitializedException($"{nameof(OpenGlDriver)} context not initialized.");
        }

        var clearColor = color.ToVector4();
        Gl.ClearColor(clearColor.X, clearColor.Y, clearColor.Z, clearColor.W);
    }

    /// <inheritdoc />
    public void Close()
    {
        CurrentWindow?.Close();
    }

    /// <inheritdoc />
    public void Clear(ClearBufferFlag clearBufferFlag = ClearBufferFlag.AllBufferBits)
    {
        var clearMask = ClearBufferMask.ColorBufferBit;

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
    }

    /// <inheritdoc />
    public void HandleEvents()
    {
        CurrentWindow?.HandleEvents();
    }

    /// <inheritdoc />
    public void Swap()
    {
        CurrentWindow?.Display();
        Time.Instance.Update();
        _input.Reset();
    }

    /// <inheritdoc />
    public IInput GetInput()
    {
        return _input;
    }

    /// <inheritdoc />
    public void DrawIndexed(IBindable bindable, DrawMode drawMode, int indexCount)
    {
        bindable.Bind();
        if (!DrawModeToBeginMode.TryGetValue(drawMode, out var beginMode))
        {
            throw new ArgumentOutOfRangeException(nameof(drawMode), drawMode, null);
        }

        Gl.DrawElements(beginMode, indexCount, DrawElementsType.UnsignedInt, nint.Zero);
    }

    /// <inheritdoc />
    public IGraphicsApi GetApi()
    {
        if (!_isInitialized)
        {
            Log.LogMessageAsync($"{nameof(OpenGlDriver)} context not initialized.", LogLevel.Error, this);
        }

        return _graphicsApi!;
    }

    private static void ShowOpenGlExtensions()
    {
        // Get GL infos
        Console.WriteLine($"OpenGL: {Gl.Version()}.{Gl.VersionMinor()}");
        Console.WriteLine($"GLSL: {Gl.GetString(StringName.ShadingLanguageVersion)}");
        Console.WriteLine($"GPU: {Gl.GetString(StringName.Renderer)}");
        Console.WriteLine("Extensions:");

        var defaultColor = Console.ForegroundColor;
        var extensionsOrdered = new Dictionary<string, bool>();

        foreach (var ext in Gl.GetExtensions())
        {
            var supported = Gl.IsExtensionSupported(Enum.Parse<Extension>(ext));
            extensionsOrdered.Add(ext, supported);
        }

        foreach (var kvp in extensionsOrdered.OrderByDescending(e => e.Value))
        {
            Console.ForegroundColor = defaultColor;
            Console.Write($"\t{kvp.Key} - ");

            string text;
            if (kvp.Value)
            {
                text = "Supported";
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                text = "Not-Supported";
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.Write($"{text}\n");
        }
    }
}
