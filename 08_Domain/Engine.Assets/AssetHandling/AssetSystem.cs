using Engine.Assets.Assets;
using Engine.Assets.Assets.Images;
using Engine.Assets.Assets.Material;
using Engine.Assets.Assets.Shaders;

namespace Engine.Assets.AssetHandling;

public sealed class AssetSystem : IDisposable
{
    private readonly AssetCompiler _assetCompiler;
    private readonly Dictionary<string, IAsset> _loadedAssets;
    private string _basePath;

    /// <summary>
    ///     Set or get the base path for the asset system
    /// </summary>
    public string BasePath
    {
        get => _basePath;
        set =>
            _basePath = value.EndsWith("\\") || value.EndsWith(@"\")
                ? value
                : $@"{value}\";
    }

    /// <summary>
    ///     Create new instance of <see cref="AssetSystem" />
    /// </summary>
    /// <param name="basePath"></param>
    public AssetSystem(string basePath)
    {
        _loadedAssets = new Dictionary<string, IAsset>();

        _basePath = string.Empty;
        BasePath = basePath;

        _assetCompiler = new AssetCompiler();
        _assetCompiler.RegisterFileConverter(new ShaderAssetConverter());
        _assetCompiler.RegisterFileConverter(new ImageAssetConverter());
        _assetCompiler.RegisterFileConverter(new MaterialConverter());
    }

    /// <summary>
    ///     Adds a new <see cref="IAssetConverter" /> to <see cref="AssetCompiler" /> registration
    /// </summary>
    /// <param name="converter">The <see cref="IAssetConverter" /> to add</param>
    public void RegisterAssetConverter(IAssetConverter converter) => _assetCompiler.RegisterFileConverter(converter);

    /// <summary>
    /// </summary>
    /// <param name="configuration"></param>
    public void Compile(AssetCompilerConfiguration configuration) =>
        _assetCompiler.Compile(BasePath, configuration.CompileExtensions?.ToArray(), configuration.DeleteCompiledFiles);

    /// <summary>
    ///     Load asset from file
    /// </summary>
    /// <typeparam name="TAssetType">Type of asset to load</typeparam>
    /// <param name="path">Relative path to the file <see cref="BasePath" /></param>
    /// <returns>New instance of the created asset.</returns>
    public TAssetType Load<TAssetType>(string path) where TAssetType : IAsset
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            throw new ArgumentNullException(nameof(path));
        }

        path = GetRealFilePath(path);

        if (_loadedAssets.TryGetValue(path, out var loadedAsset))
        {
            return (TAssetType)loadedAsset;
        }

        var asset = Activator.CreateInstance<TAssetType>();
        asset.LoadAsset(path);
        _loadedAssets.Add(path, asset);
        return asset;
    }

    /// <summary>
    ///     Dispose
    /// </summary>
    public void Dispose()
    {
        foreach (var asset in _loadedAssets)
        {
            asset.Value.Dispose();
        }
    }

    private string GetRealFilePath(string filePath)
    {
        if (File.Exists(filePath))
        {
            return filePath;
        }

        filePath = filePath.Replace('/', '\\');

        var systemPath = Directory.GetCurrentDirectory();
        systemPath = systemPath.EndsWith(@"\", StringComparison.InvariantCultureIgnoreCase)
            ? systemPath
            : $@"{systemPath}\";

        // If path without extension add .cda
        filePath = Path.GetExtension(filePath) != ""
            ? filePath
            : $"{filePath}.cda";

        var resultPath = $"{systemPath}{BasePath}{filePath}";
        if (File.Exists(resultPath) == false)
        {
            throw new FileNotFoundException(resultPath);
        }

        return resultPath;
    }
}
