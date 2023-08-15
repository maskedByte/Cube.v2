using System.Diagnostics.CodeAnalysis;
using Engine.Core.Driver;
using Engine.Core.Driver.Graphics.Buffers;
using Engine.Core.Driver.Graphics.Shaders;
using Engine.Core.Driver.Graphics.Textures;
using Engine.Core.Driver.Window;
using Engine.Core.Math.Base;
using Engine.Core.Memory.Pixmap;
using Engine.OpenGL.GraphicsApi.Buffers;
using Engine.OpenGL.GraphicsApi.Shaders;
using Engine.OpenGL.GraphicsApi.Texture;
using Engine.OpenGL.Vendor.OpenGL.Core;
using TextureBufferTarget = Engine.Core.Driver.Graphics.Textures.TextureBufferTarget;

namespace Engine.OpenGL.GraphicsApi;

/// <summary>
///     Implementation of a graphics context
/// </summary>
[SuppressMessage("Performance", "CA1822:Member als statisch markieren")]
internal class Context : IContext
{
    private static readonly Dictionary<PrimitiveType, BeginMode> DrawModeToBeginMode = new()
    {
        { PrimitiveType.Points, BeginMode.Points },
        { PrimitiveType.Lines, BeginMode.Lines },
        { PrimitiveType.LineLoop, BeginMode.LineLoop },
        { PrimitiveType.LineStrip, BeginMode.LineStrip },
        { PrimitiveType.Triangles, BeginMode.Triangles },
        { PrimitiveType.TriangleStrip, BeginMode.TriangleStrip },
        { PrimitiveType.TriangleFan, BeginMode.TriangleFan },
        { PrimitiveType.Quads, BeginMode.Triangles }, // Adjust as needed
        { PrimitiveType.Polygon, BeginMode.Triangles } // Adjust as needed
    };

    private readonly IDriver _driver;
    private readonly IWindow _window;

    /// <inheritdoc />
    public bool IsInitialized { get; private set; }

    /// <summary>
    ///     Constructor for a graphics context
    /// </summary>
    /// <param name="driver">Instance of the driver</param>
    /// <exception cref="InvalidOperationException">If the driver is not initialized</exception>
    public Context(IDriver driver)
    {
        ArgumentNullException.ThrowIfNull(driver);
        _driver = driver;

        _window = _driver.GetWindow()!;
        if (_window == null)
        {
            throw new InvalidOperationException("Window is not initialized.");
        }
    }

    /// <inheritdoc />
    public void Initialize()
    {
        Gl.PointSize(2f);
        Gl.Enable(EnableCap.DepthTest);

        Gl.Enable(EnableCap.CullFace);
        Gl.CullFace(CullFaceMode.Back);
        Gl.FrontFace(FrontFaceDirection.Ccw);
        Gl.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);

        Gl.Enable(EnableCap.Blend);
        Gl.DepthFunc(DepthFunction.Less);
        Gl.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
        Gl.Viewport(0, 0, _window.Viewport.Width, _window.Viewport.Height);

        IsInitialized = true;
    }

    /// <inheritdoc />
    public string GetVersion() => $"OpenGL: {Gl.Version()}.{Gl.VersionMinor()}";

    /// <inheritdoc />
    public string GetVendor() => $"Vendor: {Gl.GetString(StringName.Vendor)}";

    /// <inheritdoc />
    public string GetRenderer() => $"Renderer: {Gl.GetString(StringName.Renderer)}";

    /// <inheritdoc />
    public string GetShadingLanguageVersion() => $"GLSL: {Gl.GetString(StringName.ShadingLanguageVersion)}";

    /// <inheritdoc />
    public IEnumerable<string> GetSupportedExtension()
    {
        var result = new List<string>();

        foreach (var extension in Gl.GetExtensions())
        {
            Console.WriteLine(extension);

            var supported = Gl.IsExtensionSupported(Enum.Parse<Extension>(extension));
            if (supported)
            {
                result.Add(extension);
            }
        }

        return result;
    }

    /// <inheritdoc />
    public void SetClearColor(Color color)
    {
        var clearColor = color.ToVector4();
        Gl.ClearColor(clearColor.X, clearColor.Y, clearColor.Z, clearColor.W);
    }

    /// <inheritdoc />
    public void DrawIndexed(IBufferArray bufferArray, PrimitiveType primitiveType, int indexCount)
    {
        bufferArray.Bind();
        Gl.DrawElements(DrawModeToBeginMode[primitiveType], indexCount, DrawElementsType.UnsignedInt, nint.Zero);
    }

    /// <inheritdoc />
    public IBufferArray CreateBufferArray() => new GlBufferArray();

    /// <inheritdoc />
    public IBufferObject CreateBuffer(IBufferLayout bufferLayout) => new GlBufferObject(bufferLayout);

    /// <inheritdoc />
    public IBufferObject CreateIndexBuffer(IBufferLayout bufferLayout) => new GlBufferObject(bufferLayout, true);

    /// <inheritdoc />
    public IShader CreateShader(ShaderSourceType shaderSourceType, string source) => new GlShader(shaderSourceType, source);

    /// <inheritdoc />
    public IShaderProgram CreateShaderProgram() => new GlShaderProgram();

    /// <inheritdoc />
    public ITexture CreateTexture(TextureBufferTarget textureBufferTarget, IPixmap pixmap) => new GlTexture(textureBufferTarget, pixmap);

    /// <inheritdoc />
    public IUniformBuffer CreateUniformBuffer(string name, IBufferLayout bufferLayout, uint bindingSlotId) =>
        new GlUniformBuffer(name, bufferLayout, bindingSlotId);

    /// <inheritdoc />
    public IFrameBuffer CreateFrameBuffer(uint width, uint height, ITexture[] renderTargets) =>
        new GlFramebuffer(width, height, renderTargets);

    /// <inheritdoc />
    public IRenderBuffer CreateRenderBuffer() => throw new NotImplementedException();

    /// <inheritdoc />
    public void Dispose()
    {
    }
}
