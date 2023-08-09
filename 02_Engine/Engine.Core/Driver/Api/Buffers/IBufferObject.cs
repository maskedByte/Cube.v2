using Engine.Core.Math.Geometrics;
using Engine.Core.Math.Vectors;

namespace Engine.Core.Driver.Api.Buffers;

public interface IBufferObject : IBindable, IDisposable
{
    /// <summary>
    /// Returns the internal id of the api buffer
    /// </summary>
    /// <returns></returns>
    uint GetId();

    /// <summary>
    /// Set the <see cref="BufferLayout"/> for the VertexBuffer
    /// </summary>
    /// <param name="layout">Layout to use in this VertexBuffer</param>
    void SetLayout(IBufferLayout layout);

    /// <summary>
    /// Return the actual used <see cref="BufferLayout"/>
    /// </summary>
    /// <returns><see cref="BufferLayout"/></returns>
    IBufferLayout GetLayout();

    /// <summary>
    /// Set data as <see cref="Vertex"/> array
    /// </summary>
    /// <param name="data"></param>
    void SetData(Vertex[] data);

    /// <summary>
    /// Set data as <see cref="Vector2"/> array
    /// </summary>
    /// <param name="data"></param>
    void SetData(Vector2[] data);

    /// <summary>
    /// Set data as <see cref="Vector3"/> array
    /// </summary>
    /// <param name="data"></param>
    void SetData(Vector3[] data);

    /// <summary>
    /// Set data as <see cref="int"/> array
    /// </summary>
    /// <param name="data"></param>
    void SetData(int[] data);

    /// <summary>
    /// Set data as <see cref="float"/> array
    /// </summary>
    /// <param name="data"></param>
    void SetData(float[] data);
}
