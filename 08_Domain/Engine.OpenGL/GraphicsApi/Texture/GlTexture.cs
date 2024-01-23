using System.Runtime.InteropServices;
using Engine.Core.Driver.Graphics.Textures;
using Engine.Core.Logging;
using Engine.Core.Memory.Pixmap;
using Engine.OpenGL.Vendor.OpenGL.Core;
using PixelFormat = Engine.OpenGL.Vendor.OpenGL.Core.PixelFormat;
using TextureBufferTarget = Engine.Core.Driver.Graphics.Textures.TextureBufferTarget;

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

namespace Engine.OpenGL.GraphicsApi.Texture;

internal class GlTexture : ITexture
{
    private readonly IDictionary<TextureBufferTarget, TextureTarget> _targetMap = new Dictionary<TextureBufferTarget, TextureTarget>
    {
        { TextureBufferTarget.Texture1D, TextureTarget.Texture1D },
        { TextureBufferTarget.Texture2D, TextureTarget.Texture2D },
        { TextureBufferTarget.Texture3D, TextureTarget.Texture3D },
        { TextureBufferTarget.TextureCubeMap, TextureTarget.TextureCubeMap },
        { TextureBufferTarget.Texture1DArray, TextureTarget.Texture1DArray },
        { TextureBufferTarget.Texture2DArray, TextureTarget.Texture2DArray },
        { TextureBufferTarget.Texture2DMultisample, TextureTarget.Texture2DMultisample },
        { TextureBufferTarget.Texture2DMultisampleArray, TextureTarget.Texture2DMultisampleArray }
    };

    private readonly TextureTarget _textureTarget;

    private bool _allocated;
    private uint _textureId;

    /// <inheritdoc />
    public TextureBufferTarget Target { get; }

    /// <inheritdoc />
    public IPixmap Pixmap { get; private set; }

    /// <inheritdoc />
    public int Width => Pixmap.Size.Width;

    /// <inheritdoc />
    public int Height => Pixmap.Size.Height;

    public GlTexture(TextureBufferTarget textureBufferTarget, IPixmap data)
    {
        if (textureBufferTarget != TextureBufferTarget.Texture2D)
        {
            throw new NotImplementedException("This texture target is not implemented yet!");
        }

        _textureId = 0;
        Pixmap = data;
        _allocated = false;
        Target = textureBufferTarget;
        _textureTarget = _targetMap[textureBufferTarget];

        SetTextureData(data);
    }

    /// <inheritdoc />
    public void Bind() => Bind(0);

    /// <inheritdoc />
    public void Unbind() => GlStateWatch.UnbindTexture(_textureTarget, 0);

    /// <inheritdoc />
    public void Dispose() => Gl.DeleteTexture(_textureId);

    /// <inheritdoc />
    public uint GetId() => _textureId;

    /// <inheritdoc />
    public void SetTextureFilter(TextureFilter filter)
    {
        if (_allocated)
        {
            switch (filter)
            {
                case TextureFilter.Nearest:
                    Gl.TextureParameteri(
                        _textureId,
                        TextureParameterName.TextureMinFilter,
                        TextureParameter.Nearest
                    );
                    Gl.TextureParameteri(
                        _textureId,
                        TextureParameterName.TextureMagFilter,
                        TextureParameter.Nearest
                    );
                    break;
                case TextureFilter.Linear:
                    Gl.TextureParameteri(
                        _textureId,
                        TextureParameterName.TextureMinFilter,
                        TextureParameter.Linear
                    );
                    Gl.TextureParameteri(
                        _textureId,
                        TextureParameterName.TextureMagFilter,
                        TextureParameter.Linear
                    );
                    break;
                case TextureFilter.Anisotropic:
                    Gl.TextureParameteri(
                        _textureId,
                        TextureParameterName.TextureMinFilter,
                        TextureParameter.Linear
                    );
                    Gl.TextureParameteri(
                        _textureId,
                        TextureParameterName.TextureMagFilter,
                        TextureParameter.Linear
                    );
                    Gl.TextureParameterf(_textureId, TextureParameterName.MaxAnisotropyExt, 8f);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(filter), filter, null);
            }
        }
        else
        {
            Log.LogMessageAsync("#Error# Texture not created!", LogLevel.Error, this);
        }
    }

    /// <inheritdoc />
    public void Bind(uint textureUnit) => GlStateWatch.BindTexture(_textureTarget, textureUnit, _textureId);

    /// <inheritdoc />
    public void ChangePixmap(IPixmap data)
    {
        Pixmap = data;

        SetTextureData(data, false);
    }

    /// <inheritdoc />
    public void GetFromGpuMemory()
    {
        Bind();
        var pixelData = new byte[Pixmap.GetRaw().Length];
        var pinned = GCHandle.Alloc(pixelData, GCHandleType.Pinned);
        Gl.GetTexImage(
            _textureTarget,
            0,
            PixelFormat.Rgba,
            PixelType.UnsignedByte,
            (nint)pinned.AddrOfPinnedObject().ToInt64()
        );
        Gl.CheckError($"{nameof(GlTexture)}#Gl.GetTexImage");
        Pixmap.SetRaw(pixelData);
        Unbind();
    }

    private void SetTextureData(IPixmap data, bool createTexture = true)
    {
        if (_allocated && createTexture)
        {
            Gl.DeleteTexture(_textureId);
            _allocated = false;
        }

        if (createTexture)
        {
            _textureId = Gl.GenTexture();
            Gl.CheckError($"{nameof(GlTexture)}#Gl.GenTexture");

            Gl.BindTexture(_textureTarget, _textureId);
            Gl.CheckError($"{nameof(GlTexture)}#Gl.BindTexture");

            Gl.TextureStorage2D(_textureId, 1, SizedInternalFormat.Rgba16, Width, Height);
            Gl.CheckError($"{nameof(GlTexture)}#Gl.TextureStorage2D");

            Gl.TextureParameteri(_textureId, TextureParameterName.TextureMinFilter, TextureParameter.Nearest);
            Gl.TextureParameteri(_textureId, TextureParameterName.TextureMagFilter, TextureParameter.Nearest);

            Gl.TextureParameteri(_textureId, TextureParameterName.TextureWrapR, TextureParameter.ClampToEdge);
            Gl.TextureParameteri(_textureId, TextureParameterName.TextureWrapS, TextureParameter.Repeat);
            Gl.TextureParameteri(_textureId, TextureParameterName.TextureWrapT, TextureParameter.Repeat);
        }

        // Pin data to not get GC handled while processing
        var pinned = GCHandle.Alloc(data.GetRaw(), GCHandleType.Pinned);
        Gl.TextureSubImage2D(
            _textureId,
            0,
            0,
            0,
            Width,
            Height,
            PixelFormat.Rgba,
            PixelType.UnsignedByte,
            (nint)pinned.AddrOfPinnedObject().ToInt64()
        );
        Gl.CheckError($"{nameof(GlTexture)}#Gl.TextureSubImage2D");

        Gl.GenerateMipmap(GenerateMipmapTarget.Texture2D);
        Gl.CheckError($"{nameof(GlTexture)}#Gl.GenerateMipmap");

        _allocated = true;
        pinned.Free();
        Unbind();
        Gl.BindTexture(_textureTarget, 0);
    }
}
