using Engine.Core.Driver.Graphics.Buffers;
using Engine.Core.Driver.Graphics.Textures;
using Engine.Core.Logging;
using Engine.OpenGL.Vendor.OpenGL.Core;

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

namespace Engine.OpenGL.Driver.GraphicsApi.Buffers;

/// <summary>
///     Implementation of <see cref="GlFramebuffer" />
/// </summary>
internal class GlFramebuffer : IFrameBuffer
{
    private readonly uint _bufferId;
    private readonly ITexture[] _renderTargets;
    private readonly uint _depthStencilTexture;
    private bool _disposed;

    /// <summary>
    ///     Create new instance of <see cref="GlFramebuffer" />
    /// </summary>
    /// <param name="width">Width of the framebuffer</param>
    /// <param name="height">Height of the framebuffer</param>
    /// <param name="renderTargets"></param>
    /// <exception cref="Exception">ArgumentOutOfRangeException if any renderTarget has different size then the viewport</exception>
    public GlFramebuffer(uint width, uint height, ITexture[] renderTargets)
    {
        _bufferId = Gl.GenFramebuffer();
        Gl.BindFramebuffer(FramebufferTarget.Framebuffer, _bufferId);

        // Create color attachments
        for (var i = 0; i < renderTargets.Length; i++)
        {
            if (renderTargets[i].Width != width || renderTargets[i].Height != height)
            {
                throw new ArgumentOutOfRangeException(nameof(renderTargets));
            }

            renderTargets[i].Bind();
            Gl.FramebufferTexture2D(
                FramebufferTarget.Framebuffer,
                FramebufferAttachment.ColorAttachment0 + i,
                TextureTarget.Texture2D,
                renderTargets[i].GetId(),
                0
            );
            Gl.CheckError($"{nameof(IFrameBuffer)}#Gl.FramebufferTexture2D");
        }

        // Create and attach a depth buffer texture to the framebuffer
        var depthStencilTexture = Gl.GenTexture();
        Gl.CheckError($"{nameof(IFrameBuffer)}#Gl.GenTexture");

        Gl.BindTexture(TextureTarget.Texture2D, depthStencilTexture);
        Gl.CheckError($"{nameof(IFrameBuffer)}#Gl.BindTexture");

        Gl.TexImage2D(
            TextureTarget.Texture2D,
            0,
            PixelInternalFormat.Depth24Stencil8,
            (int)width,
            (int)height,
            0,
            PixelFormat.DepthStencil,
            PixelType.UnsignedInt248,
            nint.Zero
        );
        Gl.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureParameter.Nearest);
        Gl.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureParameter.Nearest);

        Gl.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, TextureParameter.ClampToEdge);
        Gl.TexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, TextureParameter.ClampToEdge);

        Gl.FramebufferTexture2D(
            FramebufferTarget.Framebuffer,
            FramebufferAttachment.DepthStencilAttachment,
            TextureTarget.Texture2D,
            depthStencilTexture,
            0
        );
        Gl.CheckError($"{nameof(IFrameBuffer)}#Gl.FramebufferTexture2D");

        // Check if the framebuffer is complete
        var status = Gl.CheckFramebufferStatus(FramebufferTarget.Framebuffer);
        if (status != FramebufferErrorCode.FramebufferComplete)
        {
            Log.LogMessageAsync(
                $"Frame buffer did not compile correctly.  Returned {status.ToString()}, glError: {Gl.GetError().ToString()}",
                LogLevel.Error,
                this
            );
        }

        _renderTargets = renderTargets;
        _depthStencilTexture = depthStencilTexture;

        Gl.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
        Gl.BindTexture(TextureTarget.Texture2D, 0);
    }

    // Destructor
    ~GlFramebuffer()
    {
        // Dispose the framebuffer
        Dispose();
    }

    /// <inheritdoc />
    public void Bind() => Gl.BindFramebuffer(FramebufferTarget.Framebuffer, _bufferId);

    /// <inheritdoc />
    public void Unbind() => Gl.BindFramebuffer(FramebufferTarget.Framebuffer, 0);

    /// <inheritdoc />
    public uint GetId() => _bufferId;

    /// <inheritdoc />
    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        Gl.DeleteFramebuffer(_bufferId);
        Gl.DeleteFramebuffer(_depthStencilTexture);

        GC.SuppressFinalize(this);
        _disposed = true;
    }
}
