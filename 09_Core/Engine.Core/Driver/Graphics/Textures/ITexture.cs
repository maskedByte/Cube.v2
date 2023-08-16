using Engine.Core.Memory.Pixmap;

namespace Engine.Core.Driver.Graphics.Textures;

/// <summary>
///     Base interface for all textures.
/// </summary>
public interface ITexture : IBindable, IDisposable
{
    /// <summary>
    ///     Get the <see cref="TextureBufferTarget" /> for this <see cref="ITexture" />.
    /// </summary>
    TextureBufferTarget Target { get; }

    /// <summary>
    ///     Set the <see cref="IPixmap" /> for this <see cref="ITexture" />.
    /// </summary>
    IPixmap Pixmap { get; }

    /// <summary>
    ///     Width of the <see cref="ITexture" />.
    /// </summary>
    int Width { get; }

    /// <summary>
    ///     height of the <see cref="ITexture" />.
    /// </summary>
    int Height { get; }

    /// <summary>
    ///     Get the id of the <see cref="ITexture" />.
    /// </summary>
    /// <returns>Returns the id of the <see cref="ITexture" />.</returns>
    uint GetId();

    /// <summary>
    ///     Bind the <see cref="ITexture" /> to a specific texture unit.
    /// </summary>
    /// <param name="textureUnit"></param>
    void Bind(uint textureUnit);

    /// <summary>
    ///     Set the <see cref="TextureFilter" /> for this <see cref="ITexture" />.
    /// </summary>
    /// <param name="filter">The <see cref="TextureFilter" /> to set.</param>
    void SetTextureFilter(TextureFilter filter);

    /// <summary>
    ///     Change the <see cref="IPixmap" /> for this <see cref="ITexture" />.
    /// </summary>
    /// <param name="data">The new <see cref="IPixmap" />.</param>
    void ChangePixmap(IPixmap data);

    /// <summary>
    ///     Get the <see cref="IPixmap" /> from the GPU memory and store it in the <see cref="IPixmap" /> property.
    /// </summary>
    void GetFromGpuMemory();
}
