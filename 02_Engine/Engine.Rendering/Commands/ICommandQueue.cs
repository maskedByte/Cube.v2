namespace Engine.Rendering.Commands;

/// <summary>
///     Interface for a render command queue
/// </summary>
public interface ICommandQueue : IDisposable
{
    /// <summary>
    ///     Enqueue a render command group
    /// </summary>
    /// <param name="commandGroup">The group of commands to enqueue</param>
    void Enqueue(CommandGroup commandGroup);

    /// <summary>
    ///     Try to dequeue a render command group
    /// </summary>
    /// <param name="commandGroup">The command group that was dequeued</param>
    /// <returns>True if a command group was dequeued, false otherwise</returns>
    bool TryDequeue(out CommandGroup? commandGroup);

    /// <summary>
    ///     Dequeue a render command group
    /// </summary>
    CommandGroup? Dequeue();
}
