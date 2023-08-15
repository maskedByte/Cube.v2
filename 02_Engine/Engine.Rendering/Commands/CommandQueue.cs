using Engine.Core.Rendering.Commands;

namespace Engine.Rendering.Commands;

/// <summary>
///     Implementation of <see cref="ICommandQueue" />
/// </summary>
public class CommandQueue : ICommandQueue
{
    private readonly Queue<CommandGroup> _commandGroups;

    /// <summary>
    ///     Default constructor
    /// </summary>
    public CommandQueue()
    {
        _commandGroups = new Queue<CommandGroup>();
    }

    /// <inheritdoc />
    public void Enqueue(CommandGroup command) => _commandGroups.Enqueue(command);

    /// <inheritdoc />
    public bool TryDequeue(out CommandGroup? commandGroup)
    {
        if (_commandGroups.Count == 0)
        {
            commandGroup = null;
            return false;
        }

        commandGroup = _commandGroups.Dequeue();
        return true;
    }

    /// <inheritdoc />
    public CommandGroup? Dequeue() =>
        _commandGroups.Count == 0
            ? null
            : _commandGroups.Dequeue();

    /// <inheritdoc />
    public void Dispose()
    {
        foreach (var commGroup in _commandGroups.Where(g => g.Any()))
        {
            commGroup.ReleaseCommands();
        }
    }
}
