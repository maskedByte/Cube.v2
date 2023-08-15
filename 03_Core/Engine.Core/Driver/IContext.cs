using Engine.Core.Driver.Graphics.Buffers;
using Engine.Core.Driver.Graphics.Shaders;
using Engine.Core.Driver.Graphics.Textures;
using Engine.Core.Math.Base;
using Engine.Core.Memory.Pixmap;

namespace Engine.Core.Driver;

/// <summary>
///     Interface for a graphics context
/// </summary>
public interface IContext : IDisposable
{
    /// <summary>
    ///     Ensure that the driver is initialized before calling driver specific methods
    /// </summary>
    bool IsInitialized { get; }

    /// <summary>
    ///     Initialize the graphics context
    /// </summary>
    void Initialize();

    /// <summary>
    ///     Return the version of the used hardware driver
    /// </summary>
    /// <returns>Version of the used graphics driver</returns>
    string GetVersion();

    /// <summary>
    ///     Get the vendor name of the used graphics hardware
    /// </summary>
    /// <returns>Returns the vendor of the used graphics hardware</returns>
    string GetVendor();

    /// <summary>
    ///     Get the renderer name of the used graphics hardware
    /// </summary>
    /// <returns>String containing the renderer name</returns>
    string GetRenderer();

    /// <summary>
    ///     Get the shading language version of the used graphics hardware
    /// </summary>
    /// <returns>Returns the shading language version of the used graphics hardware</returns>
    string GetShadingLanguageVersion();

    /// <summary>
    ///     Get supported file extensions for used graphics context
    /// </summary>
    /// <returns>Supported extensions</returns>
    IEnumerable<string> GetSupportedExtension();

    /// <summary>
    ///     Set the clear color of the frame buffer
    /// </summary>
    /// <param name="color">The color to set</param>
    void SetClearColor(Color color);

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
    ///     Create a new <see cref="IShader" />
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

    /// <summary>
    ///     Render indexed triangles to actual frame buffer
    /// </summary>
    /// <param name="bindable">A <see cref="IBufferArray" /> to render</param>
    /// <param name="primitiveType">Set draw mode, <see cref="PrimitiveType" /></param>
    /// <param name="indexCount">Set count of indices to render</param>
    void DrawIndexed(IBufferArray bindable, PrimitiveType primitiveType, int indexCount);
}
