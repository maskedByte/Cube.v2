using Engine.Assets.Assets;
using Engine.Assets.Assets.Images;
using Engine.Assets.Assets.Material;
using Engine.Assets.Assets.Shaders;

namespace Engine.Assets.AssetHandling;

/// <summary>
///     Content loader
/// </summary>
public sealed class AssetManager : IDisposable
{
    private readonly AssetCompiler _assetCompiler;
    private readonly string _baseAssetPath = null!;
    private readonly Dictionary<string, IAsset> _loadedAssets;

    /// <summary>
    ///     Singleton instance of <see cref="AssetManager" />
    /// </summary>
    public static AssetManager Instance { get; } = new();

    /// <summary>
    ///     Base path for all assets to load
    /// </summary>
    public string BaseAssetPath
    {
        get => _baseAssetPath;
        init =>
            _baseAssetPath = value.EndsWith("\\") || value.EndsWith(@"\")
                ? value
                : $@"{value}\";
    }

    static AssetManager()
    {
    }

    private AssetManager()
    {
        _loadedAssets = new Dictionary<string, IAsset>();
        BaseAssetPath = "Base";

        _assetCompiler = new AssetCompiler();

        _assetCompiler.RegisterFileConverter(new ShaderAssetConverter());
        _assetCompiler.RegisterFileConverter(new ImageAssetConverter());
        _assetCompiler.RegisterFileConverter(new MaterialConverter());

        //_assetCompiler.RegisterFileConverter(new TilemapAssetConverter());
        // _assetCompiler.RegisterFileConverter(new FontAssetConverter());
        // _assetCompiler.RegisterFileConverter(new ScriptConverter());
        // _assetCompiler.RegisterFileConverter(new SoundConverter());
        // _assetCompiler.RegisterFileConverter(new AnimationConverter());
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

    /// <summary>
    ///     Load asset from file
    /// </summary>
    /// <typeparam name="TAssetType">Type of asset to load</typeparam>
    /// <param name="path">Relative path to the file <see cref="BaseAssetPath" /></param>
    /// <returns>New instance of the created asset.</returns>
    public TAssetType LoadAsset<TAssetType>(string path) where TAssetType : IAsset
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
    ///     Compile assets
    ///     <remarks>Should only done on DEV systems</remarks>
    /// </summary>
    /// <param name="path">Set path if the<see cref="BaseAssetPath" /> is not set.</param>
    /// <param name="removeSourceAfterCompile">If set to true it will remove compiled files</param>
    /// <param name="extensions"></param>
    public void Compile(
        string path = "Base",
        string[]? extensions = null,
        bool removeSourceAfterCompile = false
    ) =>
        _assetCompiler.Compile(
            !string.IsNullOrWhiteSpace(path)
                ? path
                : _baseAssetPath,
            extensions,
            removeSourceAfterCompile
        );

    /// <summary>
    ///     Adds a new <see cref="IAssetConverter" /> to <see cref="AssetCompiler" /> registration
    /// </summary>
    /// <param name="converter">The <see cref="IAssetConverter" /> to add</param>
    public void RegisterAssetConverter(IAssetConverter converter) => _assetCompiler.RegisterFileConverter(converter);

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

        var resultPath = $"{systemPath}{BaseAssetPath}{filePath}";
        if (File.Exists(resultPath) == false)
        {
            throw new FileNotFoundException(resultPath);
        }

        return resultPath;
    }
}
