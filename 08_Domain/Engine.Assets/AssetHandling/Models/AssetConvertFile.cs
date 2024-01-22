namespace Engine.Assets.AssetHandling.Models;

public readonly struct AssetConvertFile
{
    public string FileExtension { get; init; }
    public string FileName { get; init; }
    public string FilePath { get; init; }

    public string TargetFileName => $"{FilePath}{FileName}.cda";
    public string SourceFileName => $"{FilePath}{FileName}.{FileExtension}";
}
