using Engine.Assets.AssetHandling.Models;

namespace Engine.Assets.Assets;

/// <summary>
///     <see cref="IAssetConverter" /> interface
/// </summary>
public interface IAssetConverter
{
    /// <summary>
    ///     Set associated file extensions for this <see cref="IAssetConverter" />
    ///     <remarks>Multiple divided by semicolon</remarks>
    /// </summary>
    IEnumerable<string> Extensions { get; }

    /// <summary>
    ///     Convert all files given by <paramref name="assetConvertFile" />
    /// </summary>
    /// <param name="assetConvertFile">File to convert</param>
    void Convert(AssetConvertFile assetConvertFile);

    /// <summary>
    ///     Write some output to show progress
    /// </summary>
    public static void WriteConsoleProgressStart(AssetConvertFile assetConvertFile) =>
        Console.WriteLine($"Convert: {assetConvertFile.FileName}.{assetConvertFile.FileExtension}");
}
