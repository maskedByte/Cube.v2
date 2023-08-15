namespace Engine.Core.Rendering.Commands;

/// <summary>
///     Base interface for all commands
/// </summary>
public interface ICommand
{
    /// <summary>
    ///     The unique id of the command
    /// </summary>
    Guid Id { get; }

    /// <summary>
    ///     The priority of the command
    /// </summary>
    int Priority { get; init; }

    /// <summary>
    ///     Gets or sets the type of the render command.
    /// </summary>
    CommandType Type { get; init; }
}
