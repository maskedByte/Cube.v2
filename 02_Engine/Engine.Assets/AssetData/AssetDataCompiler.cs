namespace Engine.Assets.AssetData;

/// <summary>
///     Instance of <see cref="AssetDataCompiler" />, provides functionality to convert files to engine format
/// </summary>
public sealed class AssetDataCompiler
{
    private readonly Dictionary<string, IAssetConverter> _converters;
    private IEnumerable<string> _assetFiles;

    /// <summary>
    ///     Initialize new instance of <see cref="AssetDataCompiler" />
    /// </summary>
    public AssetDataCompiler()
    {
        _assetFiles = null!;
        _converters = new Dictionary<string, IAssetConverter>();
    }

    /// <summary>
    ///     Register new <see cref="IAssetConverter" /> to collection
    /// </summary>
    /// <param name="assetFileConverter">Instance of <see cref="IAssetConverter" /> to convert files of specific type</param>
    public void RegisterFileConverter(IAssetConverter assetFileConverter) =>
        _converters.Add(assetFileConverter.Extensions, assetFileConverter);

    /// <summary>
    ///     Compile files by <paramref name="basePath" />
    /// </summary>
    /// <param name="basePath">Path to asset files</param>
    /// <param name="extensionsToCompile"></param>
    /// <param name="removeSourceAfterCompile">Remove files after compile</param>
    public void CompileAsync(
        string basePath,
        string[]? extensionsToCompile = null,
        bool removeSourceAfterCompile = false
    )
    {
        _assetFiles = Directory
           .EnumerateFiles(basePath, "*.*", SearchOption.AllDirectories)
           .Where(x => !x.EndsWith(".cda"))
           .ToList();

        var converterList = new Dictionary<string, IAssetConverter>();
        if (extensionsToCompile != null)
        {
            foreach (var extension in extensionsToCompile)
            {
                var converter = _converters.SingleOrDefault(
                        x =>
                            x.Key.Contains(extension, StringComparison.InvariantCultureIgnoreCase)
                    )
                   .Value;
                if (converter != null)
                {
                    converterList.Add(converter.Extensions, converter);
                }
            }
        }
        else
        {
            converterList = _converters;
        }

        foreach (var converter in converterList)
        {
            converter.Value.Convert(
                GetFilesForExtensions(converter.Value.Extensions, _assetFiles),
                removeSourceAfterCompile
            );
        }
    }

    private static IEnumerable<string> GetFilesForExtensions(string extensions, IEnumerable<string> files)
    {
        var extensionSplit = extensions.Trim().Split(';');
        return files.Where(x => extensionSplit.Any(y => x.EndsWith(y)));
    }
}
