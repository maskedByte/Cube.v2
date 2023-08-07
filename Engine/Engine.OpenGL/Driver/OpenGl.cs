using Engine.Driver;
using Engine.Driver.Input;
using Engine.Driver.Window;
using Engine.Math.Core;
using Engine.OpenGL.Vendor.OpenGL.Core;

namespace Engine.OpenGL.Driver;

/// <summary>
/// OpenGL driver.
/// Implements <see cref="IDriver" /> to use OpenGL 4.5 as graphics driver.
/// </summary>
public sealed class OpenGl : IDriver
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

    private readonly Input _input;

    /// <summary>
    /// Gets the current window.
    /// </summary>
    public IWindow CurrentWindow { get; private set; }

    /// <summary>
    /// Default parameterless constructor.
    /// </summary>
    public OpenGl()
    {
        CurrentWindow = null!;
        _input = new Input() ?? throw new NullReferenceException(nameof(_input));
    }

    /// <inheritdoc />
    public IWindow CreateWindow(int width, int height, bool vSync, bool showStats)
    {
        CurrentWindow = new Window(width, height, vSync);

        // Init openGl context
        Gl.PointSize(2f);
        Gl.Enable(EnableCap.DepthTest);

        Gl.Enable(EnableCap.CullFace);
        Gl.CullFace(CullFaceMode.Back);
        Gl.FrontFace(FrontFaceDirection.Cw);

        Gl.Enable(EnableCap.Blend);
        Gl.DepthFunc(DepthFunction.Less);
        Gl.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);

        if (showStats)
        {
            ShowOpenGlExtensions();
        }

        ((Window)CurrentWindow).SetInput(_input);

        return CurrentWindow;
    }

    /// <inheritdoc />
    public void SetClearColor(Color color)
    {
        var clearColor = color.ToVector4();
        Gl.ClearColor(clearColor.X, clearColor.Y, clearColor.Z, clearColor.W);
    }

    /// <inheritdoc />
    public void Close()
    {
        CurrentWindow.Close();
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
        CurrentWindow.HandleEvents();
    }

    /// <inheritdoc />
    public void Swap()
    {
        CurrentWindow.Display();
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
