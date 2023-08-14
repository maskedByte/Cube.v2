namespace Engine.Rendering.Commands;

/// <summary>
///     Interface for a render command queue
/// </summary>
public interface IRenderCommandQueue
{
    /// <summary>
    ///     Enqueue a render command
    /// </summary>
    /// <param name="command">Render command to enqueue</param>
    void Enqueue(RenderCommand command);

    /// <summary>
    ///     Dequeue a render command
    /// </summary>
    RenderCommand? Dequeue();
}
