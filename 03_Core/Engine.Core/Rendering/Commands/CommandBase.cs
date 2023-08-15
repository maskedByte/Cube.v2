namespace Engine.Core.Rendering.Commands;

/// <summary>
///     Base implementation of a command.
/// </summary>
public abstract class CommandBase : ICommand
{
    /// <inheritdoc />
    public Guid Id { get; } = new();

    /// <inheritdoc />
    public CommandType Type { get; }

    /// <inheritdoc />
    public int Priority { get; set; } = 0;

    /// <summary>
    ///     Creates a new base command.
    /// </summary>
    protected CommandBase(CommandType type)
    {
        Type = type;
    }
}
