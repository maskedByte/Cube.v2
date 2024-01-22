using Engine.Assets.Assets;

namespace Engine.Assets.AssetHandling.Models;

public class AssetConvertJob
{
    private readonly IAssetConverter _converter;
    private AssetConvertFile AssetFile { get; }

    public AssetConvertJob(IAssetConverter converter, string filePath, string fileName, string fileExtension)
    {
        _converter = converter;
        filePath = filePath[..(filePath.Length - fileName.Length - fileExtension.Length - 1)];

        AssetFile = new AssetConvertFile
        {
            FilePath = filePath,
            FileName = fileName,
            FileExtension = fileExtension
        };
    }

    public void Convert(bool removeSourceAfterCompile)
    {
        IAssetConverter.WriteConsoleProgressStart(AssetFile);
        _converter.Convert(AssetFile);

        if (removeSourceAfterCompile)
        {
            File.Delete(AssetFile.SourceFileName);
            IAssetConverter.WriteDeleteSource(AssetFile);
        }

        IAssetConverter.WriteConsoleProgressEnd(AssetFile);
    }
}
