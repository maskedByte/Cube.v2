namespace Engine.Rendering.Commands;

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
    uint Priority { get; }

    /// <summary>
    ///     Gets or sets the type of the render command.
    /// </summary>
    CommandType Type { get; }
}
