namespace Engine.Rendering.Renderer;

/// <summary>
///     Interface for all renderer implementations
/// </summary>
public interface IRenderer : IDisposable
{
    /// <summary>
    ///     Render all objects
    /// </summary>
    void Render();
}
