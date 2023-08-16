namespace Engine.Assets.Assets;

/// <summary>
///     Provides a interface for assets data
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IAsset<out T> : IDisposable, IEquatable<object>
{
    /// <summary>
    ///     Return id of this Asset
    /// </summary>
    string Id { get; }

    /// <summary>
    ///     Get the source asset file path
    /// </summary>
    string SourcePath { get; }

    /// <summary>
    ///     Get the data of this asset
    /// </summary>
    T Data { get; }

    /// <summary>
    ///     Load the asset from file by passing <paramref name="path" /> as parameter
    /// </summary>
    /// <param name="path">Path to file</param>
    void LoadAsset(string path);
}
