using Engine.Assets.AssetHandling.Models;
using Engine.Assets.FileIO;

namespace Engine.Assets.Assets.Shaders;

/// <summary>
///     Implementation for <see cref="IAssetConverter" /> to convert shader files
/// </summary>
public sealed class ShaderAssetConverter : IAssetConverter
{
    /// <inheritdoc />
    public string Extensions => "shader";

    public void Convert(AssetConvertFile assetConvertFile)
    {
        var shaderSource = File.ReadAllText(assetConvertFile.FilePath);

        using var assetFile = new FileWriter(assetConvertFile.ConvertedFileName);
        assetFile.WriteHeader(AssetDataType.ShaderData);
        assetFile.Write("Data", shaderSource);
    }
}
