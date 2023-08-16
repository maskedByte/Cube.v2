namespace Engine.Core.Driver.Graphics.Buffers;

public interface IBuffer : IBindable, IDisposable
{
    /// <summary>
    ///     Return the id of this <see cref="IBuffer" />
    /// </summary>
    /// <returns>Returns an int representing the id of this <see cref="IBuffer" /></returns>
    uint GetId();
}
