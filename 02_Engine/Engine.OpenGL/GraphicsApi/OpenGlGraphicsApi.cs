using Engine.Driver.Api;
using Engine.Driver.Api.Buffers;
using Engine.Driver.Api.Renderings;
using Engine.Driver.Api.Shaders;
using Engine.Driver.Api.Textures;

namespace Engine.OpenGL.GraphicsApi;

/// <summary>
/// Provides height level access to the OpenGl graphics api
/// </summary>
public class OpenGlGraphicsApi : IGraphicsApi
{
    public IBufferArray CreateBufferArray()
    {
        throw new NotImplementedException();
    }

    public IBufferObject CreateBuffer(IBufferLayout bufferLayout)
    {
        throw new NotImplementedException();
    }

    public IShader CreateShader()
    {
        throw new NotImplementedException();
    }

    public ITexture CreateTexture()
    {
        throw new NotImplementedException();
    }

    public ITexture2D CreateTexture2D()
    {
        throw new NotImplementedException();
    }

    public ITextureCube CreateTextureCube()
    {
        throw new NotImplementedException();
    }

    public ITextureSampler CreateTextureSampler()
    {
        throw new NotImplementedException();
    }

    public IFrameBuffer CreateFrameBuffer()
    {
        throw new NotImplementedException();
    }

    public IRenderBuffer CreateRenderBuffer()
    {
        throw new NotImplementedException();
    }

    public IRenderCommand CreateRenderCommand()
    {
        throw new NotImplementedException();
    }

    public IRenderCommandQueue CreateRenderCommandQueue()
    {
        throw new NotImplementedException();
    }
}
