namespace Engine.Core.Rendering.Commands;

/// <summary>
///     Interface for a render command queue
/// </summary>
public interface ICommandQueue
{
    /// <summary>
    ///     Enqueue a render command
    /// </summary>
    /// <param name="command">Render command to enqueue</param>
    void Enqueue(ICommand command);

    /// <summary>
    ///     Dequeue a render command
    /// </summary>
    ICommand? Dequeue();
}
