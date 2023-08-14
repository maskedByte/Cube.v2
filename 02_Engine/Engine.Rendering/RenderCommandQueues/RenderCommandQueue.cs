using Engine.Rendering.Commands;

namespace Engine.Rendering.RenderCommandQueues;

/// <summary>
///     Implementation of <see cref="IRenderCommandQueue" />
/// </summary>
public class RenderCommandQueue : IRenderCommandQueue
{
    private readonly Queue<RenderCommand> _commands;

    /// <summary>
    ///     Default constructor
    /// </summary>
    public RenderCommandQueue()
    {
        _commands = new Queue<RenderCommand>();
    }

    /// <inheritdoc />
    public void Enqueue(RenderCommand command) => _commands.Enqueue(command);

    /// <inheritdoc />
    public RenderCommand? Dequeue() =>
        _commands.Count == 0
            ? null!
            : _commands.Dequeue();
}
