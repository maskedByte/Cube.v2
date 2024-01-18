namespace Engine.Assets.AssetHandling.Models;

public struct AssetConvertFile
{
    public string FileExtension { get; init; }
    public string FileName { get; init; }
    public string FilePath { get; init; }

    public string ConvertedFileName => $"{FilePath}\\{FileName}.cda";
}
