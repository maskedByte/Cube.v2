using Engine.Assets.AssetHandling.Models;
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
    public void Convert(AssetConvertFile assetConvertFile)
    {
        // Don't convert font image files
        if (assetConvertFile.FileName.Contains("-font."))
        {
            return;
        }

        using var srcStream = File.OpenRead(assetConvertFile.FilePath);
        using var memoryStream = new MemoryStream();
        srcStream.CopyTo(memoryStream);
        srcStream.Close();

        Stbi.SetFlipVerticallyOnLoad(true);
        var image = Stbi.LoadFromMemory(memoryStream, 4);

        using var assetFile = new FileWriter(assetConvertFile.ConvertedFileName);

        assetFile.WriteHeader(AssetDataType.ImageData);
        assetFile.Write("Width", image.Width);
        assetFile.Write("Height", image.Height);
        assetFile.Write("Data", image.Data);
    }
}
