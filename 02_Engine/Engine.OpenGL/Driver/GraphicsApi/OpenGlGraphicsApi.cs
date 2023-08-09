using Engine.Core.Driver.Api;
using Engine.Core.Driver.Api.Buffers;
using Engine.Core.Driver.Api.Renderings;
using Engine.Core.Driver.Api.Shaders;
using Engine.Core.Driver.Api.Textures;
using Engine.OpenGL.Driver.GraphicsApi.Buffers;
using Engine.OpenGL.Driver.GraphicsApi.Shaders;

namespace Engine.OpenGL.Driver.GraphicsApi;

/// <summary>
/// Provides height level access to the OpenGl graphics api
/// </summary>
public class OpenGlGraphicsApi : IGraphicsApi
{
    /// <inheritdoc />
    public IBufferArray CreateBufferArray()
    {
        return new GlBufferArray();
    }

    /// <inheritdoc />
    public IBufferObject CreateBuffer(IBufferLayout bufferLayout)
    {
        return new GlBufferObject(bufferLayout);
    }

    /// <inheritdoc />
    public IBufferObject CreateBufferIndex(IBufferLayout bufferLayout)
    {
        return new GlBufferObject(bufferLayout, true);
    }

    /// <inheritdoc />
    public IShader CreateShader(ShaderSourceType shaderSourceType, string[] source)
    {
        return new GlShader(shaderSourceType, source);
    }

    /// <inheritdoc />
    public IShaderProgram CreateShaderProgram()
    {
        return new GlShaderProgram();
    }

    /// <inheritdoc />
    public ITexture CreateTexture()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public ITexture2D CreateTexture2D()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public ITextureCube CreateTextureCube()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public ITextureSampler CreateTextureSampler()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public IFrameBuffer CreateFrameBuffer()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public IRenderBuffer CreateRenderBuffer()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public IRenderCommand CreateRenderCommand()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public IRenderCommandQueue CreateRenderCommandQueue()
    {
        throw new NotImplementedException();
    }
}
