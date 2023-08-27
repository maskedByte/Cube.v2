using Engine.Assets.AssetHandling;
using Engine.Core.Driver;
using Engine.OpenGL.Driver;

namespace Engine.Framework.Frameworks;

/// <summary>
///     Creates a new instance of the framework which handles most of backend things to
///     get the engine running.
/// </summary>
public sealed class EngineCore : IDisposable
{
    public string BasePath { get; }
    public AssetSystem AssetSystem { get; }

    public IDriver ActiveDriver { get; private set; }

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

    public void Dispose()
    {
    }

    public void CompileAssets(AssetCompilerConfiguration configuration) => AssetSystem.Compile(configuration);

    public IDriver CreateDriver(DriverType driverType) =>
        ActiveDriver = driverType switch
        {
            DriverType.OpenGl => new OpenGlDriver(),
            DriverType.Vulkan => throw new NotImplementedException(),
            _                 => throw new ArgumentOutOfRangeException(nameof(driverType), driverType, null)
        };
}
