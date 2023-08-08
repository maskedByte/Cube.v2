using Engine.Driver.Api.Buffers;
using Engine.Driver.Api.Renderings;
using Engine.Driver.Api.Shaders;
using Engine.Driver.Api.Textures;

namespace Engine.Driver.Api;

/// <summary>
/// Provides height level access to the graphics api
/// </summary>
public interface IGraphicsApi
{
    /// <summary>
    /// Create a new <see cref="IBufferArray" />
    /// </summary>
    /// <returns>Returns the new <see cref="IBufferArray" /></returns>
    IBufferArray CreateBufferArray();

    /// <summary>
    /// Create a new <see cref="IBufferObject" />
    /// </summary>
    /// <returns>Returns the new <see cref="IBufferObject" /></returns>
    IBufferObject CreateBuffer(IBufferLayout bufferLayout);

    /// <summary>
    /// Create a new <see cref="IBufferObject" /> for indices
    /// </summary>
    /// <returns>Returns the new <see cref="IBufferObject" /></returns>
    IBufferObject CreateBufferIndex(IBufferLayout bufferLayout);

    /// <summary>
    /// Create a new <see cref="IShader" />
    /// </summary>
    /// <returns>Returns the new <see cref="IShader" /></returns>
    IShader CreateShader(ShaderSourceType shaderSourceType, string[] source);

    /// <summary>
    /// Create a new <see cref="IShaderProgram" />
    /// </summary>
    /// <returns>Returns the new <see cref="IShaderProgram" /></returns>
    IShaderProgram CreateShaderProgram();

    /// <summary>
    /// Create a new 1D texture<see cref="ITexture" />
    /// </summary>
    /// <returns>Returns the new <see cref="ITexture" /></returns>
    ITexture CreateTexture();

    /// <summary>
    /// Create a new 2D texture<see cref="ITexture2D" />
    /// </summary>
    /// <returns>Returns the new <see cref="ITexture2D" /></returns>
    ITexture2D CreateTexture2D();

    /// <summary>
    /// Create a new Cube texture <see cref="ITextureCube" />
    /// </summary>
    /// <returns>Returns the new <see cref="ITextureCube" /></returns>
    ITextureCube CreateTextureCube();

    /// <summary>
    /// Create a new <see cref="ITextureSampler" />
    /// </summary>
    /// <returns>Returns the new <see cref="ITextureSampler" /></returns>
    ITextureSampler CreateTextureSampler();

    /// <summary>
    /// Create a new <see cref="IFrameBuffer" />
    /// </summary>
    /// <returns>Returns the new <see cref="IFrameBuffer" /></returns>
    IFrameBuffer CreateFrameBuffer();

    /// <summary>
    /// Create a new <see cref="IRenderBuffer" />
    /// </summary>
    /// <returns>Returns the new <see cref="IRenderBuffer" /></returns>
    IRenderBuffer CreateRenderBuffer();

    /// <summary>
    /// Create a new <see cref="IRenderCommand" />
    /// </summary>
    /// <returns></returns>
    IRenderCommand CreateRenderCommand();

    /// <summary>
    /// Create a new <see cref="IRenderCommandQueue" />
    /// </summary>
    /// <returns></returns>
    IRenderCommandQueue CreateRenderCommandQueue();
}
