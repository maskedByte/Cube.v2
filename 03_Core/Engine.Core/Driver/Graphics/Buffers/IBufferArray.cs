namespace Engine.Core.Driver.Graphics.Buffers;

/// <summary>
///     Represents a buffer array
/// </summary>
public interface IBufferArray : IBindable, IDisposable
{
    /// <summary>
    ///     Return the id of this <see cref="IBufferArray" />
    /// </summary>
    /// <returns>Returns an int representing the id of this <see cref="IBufferArray" /></returns>
    uint GetId();

    /// <summary>
    ///     Add a new <see cref="IBufferObject" /> to <see cref="IBufferArray" />
    /// </summary>
    /// <param name="buffer">The buffer to add to the array</param>
    /// <param name="bufferType"></param>
    void AddBuffer(IBufferObject buffer, BufferType bufferType);

    /// <summary>
    ///     Build this <see cref="IBufferArray" />
    /// </summary>
    void Build();
}
