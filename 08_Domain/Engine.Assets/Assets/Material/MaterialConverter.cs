using Engine.Assets.AssetHandling.Models;
using Engine.Assets.FileIO;
using Engine.Core.Extensions;
using Engine.Core.Math.Base;
using Newtonsoft.Json;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedAutoPropertyAccessor.Global
#pragma warning disable CS8618

namespace Engine.Assets.Assets.Material;

/// <summary>
///     Implementation for <see cref="IAssetConverter" /> to convert script lua files
/// </summary>
internal sealed class MaterialConverter : IAssetConverter
{
    /// <inheritdoc />
    public IEnumerable<string> Extensions =>
        new[]
        {
            "mat"
        };

    public void Convert(AssetConvertFile assetConvertFile)
    {
        var scriptSource = File.ReadAllText(assetConvertFile.SourceFileName);
        var materialFileJson = JsonConvert.DeserializeObject<MaterialFile>(scriptSource) ?? throw new NullReferenceException();

        using var assetFile = new FileWriter(assetConvertFile.TargetFileName);

        assetFile.WriteHeader(AssetDataType.MaterialData);
        assetFile.Write("Color", Color.Parse(materialFileJson.Color));
        assetFile.Write("Tiling", materialFileJson.Tiling.ToVector2());
        assetFile.Write("Shader", materialFileJson.Shader);
        assetFile.Write("Filter", materialFileJson.Filter);

        assetFile.Write("Diffuse", materialFileJson.Channels.Diffuse);
        assetFile.Write("Detail", materialFileJson.Channels.Detail);
        assetFile.Write("Metallic", materialFileJson.Channels.Metallic);
        assetFile.Write("Normal", materialFileJson.Channels.Normal);
        assetFile.Write("Height", materialFileJson.Channels.Height);
        assetFile.Write("Emission", materialFileJson.Channels.Emission);
        assetFile.Write("DetailMask", materialFileJson.Channels.DetailMask);

        assetFile.Close();
    }
}
