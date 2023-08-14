namespace Engine.Rendering.Commands;

/// <summary>
///     Interface for all render command handler implementations
/// </summary>
public interface IRenderCommandHandler : IDisposable
{
    /// <summary>
    ///     Execute the render command
    /// </summary>
    /// <param name="command">Render command to execute</param>
    Task<ICommandResult> HandleAsync(RenderCommand command);
}
