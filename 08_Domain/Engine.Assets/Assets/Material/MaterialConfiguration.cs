using Engine.Core.Driver.Graphics.Textures;
using Engine.Core.Math.Base;
using Engine.Core.Math.Vectors;

namespace Engine.Assets.Assets.Material;

/// <summary>
///     Represents the configuration for a material, which defines how a surface is rendered.
/// </summary>
public struct MaterialConfiguration
{
    /// <summary>
    ///     Gets or initializes the color of the material.
    /// </summary>
    public Color Color { get; init; } = Color.White;

    /// <summary>
    ///     Gets or initializes the tiling factor for texture mapping.
    /// </summary>
    public Vector2 Tiling { get; init; } = Vector2.One;

    /// <summary>
    ///     Gets or initializes the file path to the shader used for rendering.
    /// </summary>
    public string ShaderFile { get; init; } = "shader\\default";

    /// <summary>
    ///     Gets or initializes the texture filter mode for the material's textures.
    /// </summary>
    public TextureFilter Filter { get; init; } = TextureFilter.Linear;

    /// <summary>
    ///     Gets or initializes the file path to the diffuse texture.
    /// </summary>
    public string DiffuseTexture { get; init; } = "textures\\no_texture";

    /// <summary>
    ///     Gets or initializes the file path to the detail texture.
    /// </summary>
    public string DetailTexture { get; init; } = string.Empty;

    /// <summary>
    ///     Gets or initializes the file path to the metallic texture.
    /// </summary>
    public string MetallicTexture { get; init; } = string.Empty;

    /// <summary>
    ///     Gets or initializes the file path to the normal texture.
    /// </summary>
    public string NormalTexture { get; init; } = string.Empty;

    /// <summary>
    ///     Gets or initializes the file path to the height texture.
    /// </summary>
    public string HeightTexture { get; init; } = string.Empty;

    /// <summary>
    ///     Gets or initializes the file path to the emission texture.
    /// </summary>
    public string EmissionTexture { get; init; } = string.Empty;

    /// <summary>
    ///     Gets or initializes the file path to the detail mask texture.
    /// </summary>
    public string DetailMaskTexture { get; init; } = string.Empty;

    /// <summary>
    ///     Initializes a new instance of the <see cref="MaterialConfiguration" /> struct.
    /// </summary>
    public MaterialConfiguration()
    {
    }
}
