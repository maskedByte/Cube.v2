namespace Engine.Core.Rendering.Commands;

/// <summary>
///     Interface for a render command queue
/// </summary>
public interface ICommandQueue
{
    /// <summary>
    ///     Enqueue a render command group
    /// </summary>
    /// <param name="commandGroup">The group of commands to enqueue</param>
    void Enqueue(CommandGroup commandGroup);

    /// <summary>
    ///     Dequeue a render command group
    /// </summary>
    CommandGroup? Dequeue();
}
