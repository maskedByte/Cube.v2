namespace Engine.Core.Rendering.Commands;

/// <summary>
///     Interface for all render command handler implementations
/// </summary>
public interface ICommandHandler : IDisposable
{
    /// <summary>
    ///     Determines if the handler can handle the render command
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    bool CanHandle(ICommand command);

    /// <summary>
    ///     Execute the render command
    /// </summary>
    /// <param name="command">Render command to execute</param>
    Task<ICommandResult> HandleAsync(ICommand command);
}
