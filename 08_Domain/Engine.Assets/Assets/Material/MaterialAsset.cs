using Engine.Assets.FileIO;
using Engine.Core.Driver.Graphics.Textures;
using Engine.Core.Math.Base;
using Engine.Core.Math.Vectors;

namespace Engine.Assets.Assets.Material;

/// <summary>
///     Asset implementation to load material files
/// </summary>
public sealed class MaterialAsset : IAsset<MaterialConfiguration>
{
    /// <inheritdoc />
    public string Id { get; }

    /// <inheritdoc />
    public string SourcePath { get; private set; }

    /// <summary>
    ///     Get the <see cref="MaterialConfiguration" /> for this material asset
    /// </summary>
    public MaterialConfiguration Data { get; private set; }

    /// <summary>
    ///     Create new instance of <see cref="IAsset" />
    /// </summary>
    public MaterialAsset()
    {
        Id = Guid.NewGuid().ToString();
        SourcePath = string.Empty;
    }

    /// <inheritdoc />
    public void LoadAsset(string path)
    {
        SourcePath = path;
        LoadData(File.OpenRead(path));
    }

    /// <inheritdoc />
    public void Dispose()
    {
    }

    private void LoadData(Stream dataStream)
    {
        using var fileReader = new FileReader(dataStream);
        fileReader.ReadHeader();

        if (fileReader.FileAssetDataType != AssetDataType.MaterialData)
        {
            throw new InvalidDataException(
                $"Asset type expecting {nameof(AssetDataType.MaterialData)} but found '{fileReader.FileAssetDataType}'"
            );
        }

        fileReader.Read("Color", out Color tmpColor);
        fileReader.Read("Tiling", out Vector2 tmpTiling);
        fileReader.Read("Shader", out string tmpShaderFile);
        fileReader.Read("Filter", out string tmpFilter);

        if (!Enum.TryParse<TextureFilter>(tmpFilter, out var filter))
        {
            filter = TextureFilter.Nearest;
        }

        fileReader.Read("Diffuse", out string tmpDiffuse);
        fileReader.Read("Detail", out string tmpDetail);
        fileReader.Read("Metallic", out string tmpMetallic);
        fileReader.Read("Normal", out string tmpNormal);
        fileReader.Read("Height", out string tmpHeight);
        fileReader.Read("Emission", out string tmpEmission);
        fileReader.Read("DetailMask", out string tmpDetailMask);

        Data = new MaterialConfiguration
        {
            Color = tmpColor,
            Tiling = tmpTiling,
            ShaderFile = tmpShaderFile,
            Filter = filter,
            DiffuseTexture = tmpDiffuse,
            DetailTexture = tmpDetail,
            MetallicTexture = tmpMetallic,
            NormalTexture = tmpNormal,
            HeightTexture = tmpHeight,
            EmissionTexture = tmpEmission,
            DetailMaskTexture = tmpDetailMask
        };
    }
}
