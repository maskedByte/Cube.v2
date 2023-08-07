namespace Engine.Driver;

/// <summary>
/// Time interface for providing timing functions
/// </summary>
public interface ITime
{
    /// <summary>
    /// Return DeltaTime
    /// </summary>
    float DeltaTime { get; }

    /// <summary>
    /// Return actual FPS
    /// </summary>
    float FramesPerSecond { get; }

    /// <summary>
    /// Return time since start
    /// </summary>
    float Millisecs { get; }

    /// <summary>
    /// Update Time
    /// </summary>
    void Update();
}
