using Engine.Assets.AssetHandling.Models;
using Engine.Assets.Assets;
using Engine.Core.Logging;

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

namespace Engine.Assets.AssetHandling;

internal sealed class AssetCompiler
{
    private readonly Dictionary<string, IAssetConverter> _converters = new();

    public void RegisterFileConverter(IAssetConverter assetFileConverter) =>
        _converters.Add(assetFileConverter.Extensions, assetFileConverter);

    public void Compile(
        string basePath,
        IEnumerable<string>? extensionsToCompile = null,
        bool removeSourceAfterCompile = false
    )
    {
        var convertJobs = Directory
           .EnumerateFiles(basePath, "*.*", SearchOption.AllDirectories)
           .Where(
                file => extensionsToCompile == null
                        || extensionsToCompile.Any(ext => file.EndsWith(ext, StringComparison.OrdinalIgnoreCase))
            )
           .Where(file => !file.EndsWith(".cda", StringComparison.OrdinalIgnoreCase))
           .Select(
                filePath =>
                {
                    var fileExtension = Path.GetExtension(filePath);
                    if (_converters.TryGetValue(fileExtension, out var converter))
                    {
                        return new AssetConvertJob(converter, filePath, Path.GetFileNameWithoutExtension(filePath), fileExtension);
                    }

                    Log.LogMessageAsync("No converter found for file extension: " + fileExtension, LogLevel.Warning, this);
                    return null;
                }
            )
           .Where(job => job != null);

        foreach (var job in convertJobs)
        {
            Task.Run(() => job!.Convert(removeSourceAfterCompile));
        }
    }
}
