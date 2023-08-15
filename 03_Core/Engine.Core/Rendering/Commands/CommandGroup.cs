using System.Collections;
using Engine.Core.Logging;

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

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
    public Guid Id { get; }

    /// <summary>
    ///     Sets the priority of this command group.
    /// </summary>
    public int Priority { get; set; }

    /// <summary>
    ///     Default constructor.
    /// </summary>
    public CommandGroup()
    {
        Id = Guid.NewGuid();
        Priority = 0;
    }

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
    ///     Adds a range of commands to the group.
    /// </summary>
    /// <param name="commands">The commands to add.</param>
    public void AddRange(IEnumerable<ICommand> commands) => _commands.AddRange(commands);

    /// <summary>
    ///     Removes a command from the group.
    /// </summary>
    /// <param name="command">The command to remove.</param>
    public void Remove(ICommand command) => _commands.Remove(command);

    /// <summary>
    ///     Replaces the first occurrence of <paramref name="oldCommand" /> with <paramref name="newCommand" />.
    /// </summary>
    /// <param name="oldCommand">The old command to replace.</param>
    /// <param name="newCommand">The new command to replace with.</param>
    public void Replace(ICommand oldCommand, ICommand newCommand)
    {
        var index = _commands.IndexOf(oldCommand);
        if (index == -1)
        {
            Log.LogMessageAsync($"Failed to replace command {oldCommand.Id} with {newCommand.Id} in group {Id}.", LogLevel.Error, this);
            return;
        }

        _commands[index] = newCommand;
    }

    /// <summary>
    ///     Resets the current index of this group.
    /// </summary>
    public void Reset() => _currentIndex = 0;

    /// <summary>
    ///     Releases all commands in this group.
    /// </summary>
    public void ReleaseCommands() => _commands.Clear();
}
