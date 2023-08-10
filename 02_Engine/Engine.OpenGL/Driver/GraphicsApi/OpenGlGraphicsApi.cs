using Engine.Core.Driver.Graphics;
using Engine.Core.Driver.Graphics.Buffers;
using Engine.Core.Driver.Graphics.Renderings;
using Engine.Core.Driver.Graphics.Shaders;
using Engine.Core.Driver.Graphics.Textures;
using Engine.OpenGL.Driver.GraphicsApi.Buffers;
using Engine.OpenGL.Driver.GraphicsApi.Shaders;

namespace Engine.OpenGL.Driver.GraphicsApi;

/// <summary>
/// Provides height level access to the OpenGl graphics api
/// </summary>
public class OpenGlGraphicsApi : IGraphicsApi
{
    /// <inheritdoc />
    public IBufferArray CreateBufferArray() => new GlBufferArray();

    /// <inheritdoc />
    public IBufferObject CreateBuffer(IBufferLayout bufferLayout) => new GlBufferObject(bufferLayout);

    /// <inheritdoc />
    public IBufferObject CreateIndexBuffer(IBufferLayout bufferLayout) => new GlBufferObject(bufferLayout, true);

    /// <inheritdoc />
    public IShader CreateShader(ShaderSourceType shaderSourceType, string[] source) => new GlShader(shaderSourceType, source);

    /// <inheritdoc />
    public IShaderProgram CreateShaderProgram() => new GlShaderProgram();

    /// <inheritdoc />
    public ITexture CreateTexture() => throw new NotImplementedException();

    /// <inheritdoc />
    public ITexture2D CreateTexture2D() => throw new NotImplementedException();

    /// <inheritdoc />
    public ITextureCube CreateTextureCube() => throw new NotImplementedException();

    /// <inheritdoc />
    public ITextureSampler CreateTextureSampler() => throw new NotImplementedException();

    /// <inheritdoc />
    public IFrameBuffer CreateFrameBuffer() => throw new NotImplementedException();

    /// <inheritdoc />
    public IRenderBuffer CreateRenderBuffer() => throw new NotImplementedException();

    /// <inheritdoc />
    public IRenderCommand CreateRenderCommand() => throw new NotImplementedException();

    /// <inheritdoc />
    public IRenderCommandQueue CreateRenderCommandQueue() => throw new NotImplementedException();
}
