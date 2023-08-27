using Engine.Rendering.Commands.TextureCommands;

namespace Engine.Rendering.Commands;

/// <summary>
///     Base implementation of a command.
/// </summary>
public abstract class CommandBase : ICommand
{
    /// <inheritdoc />
    public Guid Id { get; }

    /// <inheritdoc />
    public CommandType Type { get; }

    /// <inheritdoc />
    public uint Priority { get; set; }

    /// <summary>
    ///     Creates a new base command.
    /// </summary>
    protected CommandBase(CommandType type)
    {
        Id = Guid.NewGuid();
        Type = type;
        Priority = (uint)CommandPriority.Default;
    }
}
