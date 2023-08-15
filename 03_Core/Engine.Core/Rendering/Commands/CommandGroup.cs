using System.Collections;

namespace Engine.Core.Rendering.Commands;

/// <summary>
///     A group of commands that are executed in order of addition (FIFO).
/// </summary>
public sealed class CommandGroup : IEnumerable<ICommand>
{
    private readonly Queue<ICommand> _commands = new();

    /// <inheritdoc />
    public IEnumerator<ICommand> GetEnumerator() => _commands.GetEnumerator();

    /// <inheritdoc />
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    /// <summary>
    ///     Returns the next command in the group and casts it to the specified type.
    /// </summary>
    /// <typeparam name="TTarget">The type to cast the command to.</typeparam>
    /// <returns>If there are no more commands in the group, returns null. Otherwise, returns the next command in the group.</returns>
    public ICommand? Next<TTarget>() where TTarget : class, ICommand =>
        _commands.Count > 0
            ? (TTarget)_commands.Dequeue()
            : null;

    /// <summary>
    ///     Adds a command to the group.
    /// </summary>
    /// <param name="command">The command to add.</param>
    public void Add(ICommand command) => _commands.Enqueue(command);
}
