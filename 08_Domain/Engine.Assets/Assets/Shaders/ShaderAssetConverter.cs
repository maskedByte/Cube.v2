using Engine.Assets.FileIO;

namespace Engine.Assets.Assets.Shaders;

/// <summary>
///     Implementation for <see cref="IAssetConverter" /> to convert shader files
/// </summary>
public sealed class ShaderAssetConverter : IAssetConverter
{
    /// <inheritdoc />
    public string Extensions => "shader";

    /// <inheritdoc />
    public void Convert(IEnumerable<string> filesToConvert, bool removeSourceAfterCompile)
    {
        foreach (var file in filesToConvert)
        {
            IAssetConverter.WriteConsoleProgressStart(file);
            var shaderSource = File.ReadAllText(file);
            var pathName = Path.GetDirectoryName(file);
            var fileName = Path.GetFileNameWithoutExtension(file);

            using (var assetFile = new FileWriter($"{pathName}\\{fileName}.cda"))
            {
                assetFile.WriteHeader(AssetDataType.ShaderData);
                assetFile.Write("Data", shaderSource);
            }

            if (removeSourceAfterCompile)
            {
                File.Delete(file);
            }

            IAssetConverter.WriteConsoleProgressEnd();
        }
    }
}
