using Engine.Assets.AssetHandling;
using Engine.Core.Driver;
using Engine.OpenGL.Driver;

namespace Engine.Framework.Rendering;

/// <summary>
///     Creates a new instance of the framework which handles most of backend things to
///     get the engine running.
/// </summary>
public sealed class EngineCore : IDisposable
{
    /// <summary>
    ///     Get the asset system base path which is used to load assets from.
    /// </summary>
    public string BasePath { get; }

    /// <summary>
    ///     Get the asset system instance.
    /// </summary>
    public AssetSystem AssetSystem { get; }

    public IDriver ActiveDriver { get; private set; }

    /// <summary>
    ///     Creates a new instance of the engine core.
    /// </summary>
    /// <param name="basePath">The base path to load assets from.</param>
    /// <exception cref="ArgumentException">Thrown when the given base path is null or whitespace.</exception>
    public EngineCore(string basePath)
    {
        if (string.IsNullOrWhiteSpace(basePath))
        {
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(basePath));
        }

        BasePath = basePath;
        ActiveDriver = null!;
        AssetSystem = new AssetSystem(basePath);
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

    public T Load<T>(string assetPath) where T : class => throw new NotImplementedException();
}
