﻿using Engine.Assets.AssetHandling;
using Engine.Assets.Assets;
using Engine.Core.Driver;
using Engine.Core.Logging;
using Engine.Framework.Rendering.DataStructures;
using Engine.OpenGL.Driver;

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

namespace Engine.Framework.Rendering;

/// <summary>
///     Creates a new instance of the framework which handles most of backend things to
///     get the engine running.
/// </summary>
public sealed class EngineCore : IDisposable
{
    private static readonly object lockObject = new();

    private FileSystemWatcher _fileSystemWatcher;
    private bool _hotReload;
    private readonly Dictionary<string, DateTime> _recentlyChangedFiles;
    private readonly Dictionary<Type, List<IReloadAble>> _assetReloadRegistry;
    private List<string> _FilesToReloadOnMainThread;

    /// <summary>
    ///     Get the asset system base path which is used to load assets from.
    /// </summary>
    public string BasePath { get; }

    /// <summary>
    ///     Get the asset system instance.
    /// </summary>
    public AssetSystem AssetSystem { get; }

    /// <summary>
    ///     Set or get the hot reload flag for the asset system.
    /// </summary>
    public bool HotReload
    {
        get => _hotReload;
        set
        {
            _hotReload = value;
            if (_hotReload)
            {
                PrepareFileSystemWatcher();
            }
            else
            {
                _fileSystemWatcher.Dispose();
            }
        }
    }

    public IDriver ActiveDriver { get; private set; }

    /// <summary>
    ///     Creates a new instance of the engine core.
    /// </summary>
    /// <param name="basePath">The base path to load assets from.</param>
    /// <exception cref="ArgumentException">Thrown when the given base path is null or whitespace.</exception>
    public EngineCore(string basePath)
    {
        ArgumentException.ThrowIfNullOrEmpty(basePath);

        _assetReloadRegistry = new Dictionary<Type, List<IReloadAble>>();
        _recentlyChangedFiles = new Dictionary<string, DateTime>();
        _FilesToReloadOnMainThread = new List<string>();

        BasePath = basePath;
        _fileSystemWatcher = null!;
        ActiveDriver = null!;
        AssetSystem = new AssetSystem(basePath);
        HotReload = true;

        // Set the core for the material system.
        Texture2D.Core = this;
        Material.Core = this;
        Shader.Core = this;

        // Asset Reload job
        var reloadFile = new AssetCompilerConfiguration
        {
            DeleteCompiledFiles = false
        };

        Task.Run(async () => await FileChangeWatcher(reloadFile));
    }

    /// <summary>
    ///     Compiles all assets with the given configuration and under the given path. <see cref="BasePath" />
    /// </summary>
    /// <param name="configuration"></param>
    public void CompileAssets(AssetCompilerConfiguration configuration) => AssetSystem.Compile(configuration);

    /// <summary>
    ///     Creates a new driver instance for the given driver type.
    /// </summary>
    /// <param name="driverType">The driver type to create, <see cref="DriverType" /> for more information.</param>
    /// <returns>The newly created driver instance.</returns>
    public IDriver CreateDriver(DriverType driverType) =>
        ActiveDriver = driverType switch
        {
            DriverType.OpenGl => new OpenGlDriver(),
            DriverType.Vulkan => throw new NotImplementedException(),
            _                 => throw new ArgumentOutOfRangeException(nameof(driverType), driverType, null)
        };

    public void Dispose()
    {
        AssetSystem.Dispose();
        ActiveDriver.Dispose();
    }

    /// <summary>
    ///     Load a specific asset
    /// </summary>
    /// <param name="assetPath">URI to the asset</param>
    /// <typeparam name="T">Type of the asset</typeparam>
    /// <returns>Loaded asset</returns>
    public T? Load<T>(string assetPath) where T : IAsset => AssetSystem.Load<T>(assetPath);

    internal void CheckReload()
    {
        lock (lockObject)
        {
            if (_FilesToReloadOnMainThread.Count == 0)
            {
                return;
            }

            var files = _FilesToReloadOnMainThread.ToList();

            var retryCount = 0;
            foreach (var file in files)
            {
                var filePath = file[..^Path.GetExtension(file).Length];

                try
                {
                    var asset = AssetSystem.Load<IAsset>(filePath, true);
                    if (asset is null)
                    {
                        continue;
                    }

                    foreach (var reloadAble in _assetReloadRegistry[asset.GetType()])
                    {
                        reloadAble.TryReload(asset);
                    }

                    _FilesToReloadOnMainThread.Remove(file);
                }
                catch (Exception e)
                {
                    retryCount++;

                    if (retryCount > 5)
                    {
                        Log.LogMessageAsync($"Error while reloading asset {file}: {e.Message}", LogLevel.Error, this);
                        _FilesToReloadOnMainThread.Remove(file);
                    }
                }
            }
        }
    }

    internal void RegisterAssetReload(Type assetType, IReloadAble reloadAble)
    {
        _assetReloadRegistry.TryGetValue(assetType, out var reloadAbles);

        if (reloadAbles is null)
        {
            reloadAbles = new List<IReloadAble>();
            _assetReloadRegistry.Add(assetType, reloadAbles);
        }

        reloadAbles.Add(reloadAble);
    }

    internal void UnregisterAssetReload(IReloadAble reloadAble)
    {
        foreach (var reloadAbles in _assetReloadRegistry.Values)
        {
            reloadAbles.Remove(reloadAble);
        }
    }

    private async Task FileChangeWatcher(AssetCompilerConfiguration reloadFile)
    {
        while (true)
        {
            lock (lockObject)
            {
                if (_recentlyChangedFiles.Count > 0)
                {
                    _FilesToReloadOnMainThread = _recentlyChangedFiles.Keys.ToList();
                    _recentlyChangedFiles.Clear();

                    try
                    {
                        Task.Run(() => AssetSystem.Compile(_FilesToReloadOnMainThread, reloadFile));
                    }
                    catch (Exception e)
                    {
                        Log.LogMessageAsync($"Error while compiling assets: {e.Message}", LogLevel.Error, this);
                        Thread.Sleep(1000);
                        AssetSystem.Compile(_FilesToReloadOnMainThread, reloadFile);
                    }
                }
            }

            await Task.Delay(500);
        }
    }

    private void PrepareFileSystemWatcher()
    {
        _fileSystemWatcher = new FileSystemWatcher(BasePath);
        _fileSystemWatcher.IncludeSubdirectories = true;
        _fileSystemWatcher.EnableRaisingEvents = true;

        _fileSystemWatcher.NotifyFilter =
            NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.LastAccess;
        _fileSystemWatcher.Changed += FileChanged;
        _fileSystemWatcher.Created += FileAdded;
        _fileSystemWatcher.Deleted += FileDeleted;
    }

    private void FileChanged(object sender, FileSystemEventArgs e) =>
        AddAssetToRecentChanges(e.FullPath, File.GetLastWriteTime(e.FullPath));

    private void FileAdded(object sender, FileSystemEventArgs e) => AddAssetToRecentChanges(e.FullPath, File.GetLastWriteTime(e.FullPath));

    private void FileDeleted(object sender, FileSystemEventArgs e) =>
        AddAssetToRecentChanges(e.FullPath, File.GetLastWriteTime(e.FullPath));

    private void AddAssetToRecentChanges(string path, DateTime currentLastWriteTime)
    {
        var fileExtension = Path.GetExtension(path);

        if (!FileIsReady(path))
        {
            return;
        }

        if (fileExtension.StartsWith('.'))
        {
            fileExtension = fileExtension[1..];
        }

        if (!AssetSystem.SupportedExtensions.Contains($"*.{fileExtension}"))
        {
            return;
        }

        if (_recentlyChangedFiles.TryGetValue(path, out var lastWriteTime))
        {
            if (currentLastWriteTime - lastWriteTime < TimeSpan.FromSeconds(1))
            {
                return;
            }
        }

        _recentlyChangedFiles[path] = currentLastWriteTime;
    }

    private static bool FileIsReady(string path)
    {
        try
        {
            if (!File.Exists(path)
                || path.EndsWith(".cda")
                || (File.GetAttributes(path) & FileAttributes.Directory) == FileAttributes.Directory)
            {
                return false;
            }

            using var file = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);

            return true;
        }
        catch (IOException)
        {
            return false;
        }
    }
}
