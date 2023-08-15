using Engine.Core.Rendering.Commands;

namespace Engine.Rendering.Commands;

/// <summary>
///     Implementation of <see cref="ICommandQueue" />
/// </summary>
public class CommandQueue : ICommandQueue
{
    private readonly SortedList<int, CommandGroup> _commandGroups;

    /// <summary>
    ///     Default constructor
    /// </summary>
    public CommandQueue()
    {
        _commandGroups = new SortedList<int, CommandGroup>();
    }

    /// <inheritdoc />
    public void Enqueue(CommandGroup command) => _commandGroups.Add(command.Priority, command);

    /// <inheritdoc />
    public bool TryDequeue(out CommandGroup? commandGroup)
    {
        commandGroup = Dequeue();
        return commandGroup != null;
    }

    /// <inheritdoc />
    public CommandGroup? Dequeue()
    {
        if (_commandGroups.Count <= 0)
        {
            return null;
        }

        var firstCommand = _commandGroups.Values[0];
        _commandGroups.RemoveAt(0);
        return firstCommand;
    }

    /// <inheritdoc />
    public void Dispose()
    {
        foreach (var (_, group) in _commandGroups.Where(g => g.Value.Any()))
        {
            group.ReleaseCommands();
        }
    }
}
