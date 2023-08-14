using Engine.Core.Driver.Graphics.Buffers;
using Engine.Core.Driver.Graphics.Shaders;
using Engine.Core.Driver.Graphics.Textures;
using Engine.Core.Memory.Pixmap;

namespace Engine.Core.Driver.Graphics;

/// <summary>
///     Provides height level access to the graphics api
/// </summary>
public interface IGraphicsApi
{
    /// <summary>
    ///     Create a new <see cref="IBufferArray" />
    /// </summary>
    /// <returns>Returns the new <see cref="IBufferArray" /></returns>
    IBufferArray CreateBufferArray();

    /// <summary>
    ///     Create a new <see cref="IBufferObject" />
    /// </summary>
    /// <returns>Returns the new <see cref="IBufferObject" /></returns>
    IBufferObject CreateBuffer(IBufferLayout bufferLayout);

    /// <summary>
    ///     Create a new <see cref="IBufferObject" /> for indices
    /// </summary>
    /// <returns>Returns the new <see cref="IBufferObject" /></returns>
    IBufferObject CreateIndexBuffer(IBufferLayout bufferLayout);

    /// <summary>
    ///   Create a new <see cref="IShader" />
    /// </summary>
    /// <param name="shaderSourceType">The shader source type</param>
    /// <param name="source">The shader source</param>
    /// <returns>Returns the new <see cref="IShader" /></returns>
    IShader CreateShader(ShaderSourceType shaderSourceType, string source);

    /// <summary>
    ///     Create a new <see cref="IShaderProgram" />
    /// </summary>
    /// <returns>Returns the new <see cref="IShaderProgram" /></returns>
    IShaderProgram CreateShaderProgram();

    /// <summary>
    ///     Create a new 1D texture<see cref="ITexture" />
    /// </summary>
    /// <param name="textureBufferTarget">The texture buffer target</param>
    /// <param name="pixmap"> Pixmap data for the texture</param>
    /// <returns>Returns the new <see cref="ITexture" /></returns>
    ITexture CreateTexture(TextureBufferTarget textureBufferTarget, IPixmap pixmap);

    /// <summary>
    ///     Create a new <see cref="IUniformBuffer" />
    /// </summary>
    /// <returns>Returns the new <see cref="IUniformBuffer" /></returns>
    IUniformBuffer CreateUniformBuffer(string name, IBufferLayout bufferLayout, uint bindingSlotId);

    /// <summary>
    ///     Create a new <see cref="IFrameBuffer" />
    /// </summary>
    /// <returns>Returns the new <see cref="IFrameBuffer" /></returns>
    IFrameBuffer CreateFrameBuffer(uint width, uint height, ITexture[] renderTargets);

    /// <summary>
    ///     Create a new <see cref="IRenderBuffer" />
    /// </summary>
    /// <returns>Returns the new <see cref="IRenderBuffer" />The new <see cref="IRenderBuffer" /></returns>
    IRenderBuffer CreateRenderBuffer();
}
