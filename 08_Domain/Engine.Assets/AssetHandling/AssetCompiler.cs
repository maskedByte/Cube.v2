using Engine.Assets.Assets;

namespace Engine.Assets.AssetHandling;

internal sealed class AssetCompiler
{
    private readonly Dictionary<string, IAssetConverter> _converters = new();
    private IEnumerable<string> _assetFiles = null!;

    public void RegisterFileConverter(IAssetConverter assetFileConverter) =>
        _converters.Add(assetFileConverter.Extensions, assetFileConverter);

    public void Compile(
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
        return files.Where(x => extensionSplit.Any(x.EndsWith));
    }
}
