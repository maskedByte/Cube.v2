using Engine.Core.Rendering.Commands;

namespace Engine.Rendering.RenderCommandQueues;

/// <summary>
///     Implementation of <see cref="ICommandQueue" />
/// </summary>
public class CommandQueue : ICommandQueue
{
    private readonly Queue<ICommand> _commands;

    /// <summary>
    ///     Default constructor
    /// </summary>
    public CommandQueue()
    {
        _commands = new Queue<ICommand>();
    }

    /// <inheritdoc />
    public void Enqueue(ICommand command) => _commands.Enqueue(command);

    /// <inheritdoc />
    public ICommand? Dequeue() =>
        _commands.Count == 0
            ? null!
            : _commands.Dequeue();
}
