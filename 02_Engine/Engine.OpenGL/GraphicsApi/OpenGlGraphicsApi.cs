using Engine.Driver.Api;
using Engine.Driver.Api.Buffers;
using Engine.Driver.Api.Rendering;
using Engine.Driver.Api.Shader;
using Engine.Driver.Api.Texture;

namespace Engine.OpenGL.GraphicsApi;

/// <summary>
/// Provides height level access to the OpenGl graphics api
/// </summary>
public class OpenGlGraphicsApi : IGraphicsApi
{
    /// <inheritdoc />
    public IBufferArray CreateBufferArray()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public IBuffer CreateBuffer()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public IShader CreateShader()
    {
        throw new NotImplementedException();
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
