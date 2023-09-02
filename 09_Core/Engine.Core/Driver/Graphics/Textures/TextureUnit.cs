namespace Engine.Core.Driver.Graphics.Textures;

/// <summary>
///     Maps to the texture unit in the shader
/// </summary>
public enum TextureUnit
{
    None = -1,
    DiffuseColor = 0,
    DetailColor = 1,
    MetallicColor = 5,
    NormalColor = 6,
    HeightColor = 7,
    EmissionColor = 8,
    DetailMaskColor = 9
}
