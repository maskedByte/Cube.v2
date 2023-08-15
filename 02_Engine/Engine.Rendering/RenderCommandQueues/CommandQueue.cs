using Engine.Core.Rendering.Commands;

namespace Engine.Rendering.RenderCommandQueues;

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
    public CommandGroup? Dequeue() =>
        _commandGroups.Count == 0
            ? null
            : _commandGroups.Dequeue();
}
