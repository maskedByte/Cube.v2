using System.Collections;

namespace Engine.Core.Rendering.Commands;

/// <summary>
///     A group of commands that are executed in order of addition (FIFO).
/// </summary>
public sealed class CommandGroup : IEnumerable<ICommand>
{
    private readonly List<ICommand> _commands = new();
    private int _currentIndex;

    /// <summary>
    ///     Returns the id of this group.
    /// </summary>
    public Guid Id { get; } = new();

    /// <inheritdoc />
    public IEnumerator<ICommand> GetEnumerator() => _commands.GetEnumerator();

    /// <inheritdoc />
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    /// <summary>
    ///     Tries to get the next command in the group.
    /// </summary>
    /// <param name="command">The next command in the group.</param>
    /// <param name="commandType">The type of the next command in the group.</param>
    /// <returns>True if a command was returned, false otherwise.</returns>
    public bool TryGetNext(out ICommand command, out CommandType commandType)
    {
        if (_commands.Count == 0)
        {
            command = null!;
            commandType = CommandType.NullCommand;
            return false;
        }

        if (_currentIndex >= _commands.Count)
        {
            command = null!;
            commandType = CommandType.NullCommand;
            return false;
        }

        command = _commands[_currentIndex];
        commandType = command.Type;

        _currentIndex++;
        return true;
    }

    /// <summary>
    ///     Adds a command to the group.
    /// </summary>
    /// <param name="command">The command to add.</param>
    public void Add(ICommand command) => _commands.Add(command);

    /// <summary>
    ///     Resets the current index of this group.
    /// </summary>
    public void Reset() => _currentIndex = 0;

    /// <summary>
    ///     Releases all commands in this group.
    /// </summary>
    public void ReleaseCommands() => _commands.Clear();
}
