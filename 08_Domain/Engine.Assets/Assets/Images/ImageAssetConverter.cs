using Engine.Assets.AssetData;
using Engine.Assets.FileIO;
using StbiSharp;

namespace Engine.Assets.Assets.Images;

/// <summary>
///     Implementation for <see cref="IAssetConverter" /> to convert texture files
/// </summary>
public sealed class ImageAssetConverter : IAssetConverter
{
    /// <inheritdoc />
    public string Extensions => "jpg;jpeg;png;tga;bmp;tiff;gif";

    /// <inheritdoc />
    public void Convert(IEnumerable<string> filesToConvert, bool removeSourceAfterCompile)
    {
        foreach (var file in filesToConvert)
        {
            // Don't convert font image files
            if (file.Contains("-font."))
            {
                continue;
            }

            IAssetConverter.WriteConsoleProgressStart(file);
            using var srcStream = File.OpenRead(file);
            using var memoryStream = new MemoryStream();
            srcStream.CopyTo(memoryStream);
            srcStream.Close();

            Stbi.SetFlipVerticallyOnLoad(true);
            var image = Stbi.LoadFromMemory(memoryStream, 4);

            var fileName = Path.GetFileNameWithoutExtension(file);
            var pathName = Path.GetDirectoryName(file);

            using var assetFile = new FileWriter($"{pathName}\\{fileName}.cda");

            assetFile.WriteHeader(AssetDataType.ImageData);
            assetFile.Write("Width", image.Width);
            assetFile.Write("Height", image.Height);
            assetFile.Write("Data", image.Data);

            if (removeSourceAfterCompile)
            {
                File.Delete(file);
            }
        }

        IAssetConverter.WriteConsoleProgressEnd();
    }
}
