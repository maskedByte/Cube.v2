using Engine.Driver.Api.Buffers;
using Engine.Driver.Api.Rendering;
using Engine.Driver.Api.Shader;
using Engine.Driver.Api.Texture;

namespace Engine.Driver.Api;

/// <summary>
/// Provides height level access to the graphics api
/// </summary>
public interface IGraphicsApi
{
    /// <summary>
    /// Create a new <see cref="IBufferArray"/>
    /// </summary>
    /// <returns></returns>
    IBufferArray CreateBufferArray();

    /// <summary>
    /// Create a new <see cref="IBuffer"/>
    /// </summary>
    /// <returns></returns>
    IBuffer CreateBuffer();

    /// <summary>
    /// Create a new <see cref="IShader"/>
    /// </summary>
    /// <returns></returns>
    IShader CreateShader();

    /// <summary>
    /// Create a new 1D texture<see cref="ITexture"/>
    /// </summary>
    /// <returns></returns>
    ITexture CreateTexture();

    /// <summary>
    /// Create a new 2D texture<see cref="ITexture2D"/>
    /// </summary>
    /// <returns></returns>
    ITexture2D CreateTexture2D();

    /// <summary>
    /// Create a new Cube texture <see cref="ITextureCube"/>
    /// </summary>
    /// <returns></returns>
    ITextureCube CreateTextureCube();

    /// <summary>
    /// Create a new <see cref="ITextureSampler"/>
    /// </summary>
    /// <returns></returns>
    ITextureSampler CreateTextureSampler();

    /// <summary>
    /// Create a new <see cref="IFrameBuffer"/>
    /// </summary>
    /// <returns></returns>
    IFrameBuffer CreateFrameBuffer();

    /// <summary>
    /// Create a new <see cref="IRenderBuffer"/>
    /// </summary>
    /// <returns></returns>
    IRenderBuffer CreateRenderBuffer();

    /// <summary>
    /// Create a new <see cref="IRenderCommand"/>
    /// </summary>
    /// <returns></returns>
    IRenderCommand CreateRenderCommand();

    /// <summary>
    /// Create a new <see cref="IRenderCommandQueue"/>
    /// </summary>
    /// <returns></returns>
    IRenderCommandQueue CreateRenderCommandQueue();
}
