namespace Engine.Rendering.Commands;

/// <summary>
///     Interface for a render command queue
/// </summary>
public interface ICommandQueue : IDisposable
{
    /// <summary>
    ///     Gets whether the command queue is ready for execution
    /// </summary>
    bool IsReady { get; }

    /// <summary>
    ///     Prepare the command queue for execution
    /// </summary>
    void Begin();

    /// <summary>
    ///     Enqueue a render command group
    /// </summary>
    /// <param name="commandGroup">The group of commands to enqueue</param>
    void Enqueue(ICommand commandGroup);

    /// <summary>
    ///     Try to dequeue a render command group
    /// </summary>
    /// <param name="commandGroup">The command group that was dequeued</param>
    /// <returns>True if a command group was dequeued, false otherwise</returns>
    bool TryDequeue(out ICommand? commandGroup);

    /// <summary>
    ///     Dequeue a render command group
    /// </summary>
    ICommand? Dequeue();

    /// <summary>
    ///     Commits the command queue and prepares it for execution
    /// </summary>
    void End();
}
