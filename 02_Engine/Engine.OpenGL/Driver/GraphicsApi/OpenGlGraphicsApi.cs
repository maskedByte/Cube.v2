using Engine.Core.Driver.Graphics;
using Engine.Core.Driver.Graphics.Buffers;
using Engine.Core.Driver.Graphics.Renderings;
using Engine.Core.Driver.Graphics.Shaders;
using Engine.Core.Driver.Graphics.Textures;
using Engine.Core.Memory.Pixmap;
using Engine.OpenGL.Driver.GraphicsApi.Buffers;
using Engine.OpenGL.Driver.GraphicsApi.Shaders;
using Engine.OpenGL.Driver.GraphicsApi.Texture;

namespace Engine.OpenGL.Driver.GraphicsApi;

/// <summary>
///     Provides height level access to the OpenGl graphics api
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
    public IRenderCommand CreateRenderCommand() => throw new NotImplementedException();

    /// <inheritdoc />
    public IRenderCommandQueue CreateRenderCommandQueue() => throw new NotImplementedException();
}
