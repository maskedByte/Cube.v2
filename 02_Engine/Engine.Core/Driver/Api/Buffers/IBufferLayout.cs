namespace Engine.Driver.Api.Buffers;

/// <summary>
/// Defines a buffer layout
/// </summary>
public interface IBufferLayout
{
    /// <summary>
    /// Get the <see cref="BufferElement"/> by name
    /// </summary>
    /// <param name="name"></param>
    /// <returns>Returns a <see cref="BufferElement"/> by name</returns>
    BufferElement this[string name] { get; }

    /// <summary>
    /// Set the layout for this buffer
    /// </summary>
    void SetLayout(BufferElement[] elements);

    /// <summary>
    /// Get the length of the stride
    /// </summary>
    /// <returns>The length of the stride</returns>
    int GetStride();

    /// <summary>
    /// Add an existing <see cref="BufferElement"/> to the <see cref="IBufferLayout"/>
    /// </summary>
    /// <param name="element">The element to add</param>
    void AddElement(BufferElement element);

    /// <summary>
    /// Return the array of buffer elements
    /// </summary>
    /// <returns>Returns an array of <see cref="BufferElement"/></returns>
    BufferElement[] GetElements();
}
