namespace Engine.Rendering.Renderers;

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
