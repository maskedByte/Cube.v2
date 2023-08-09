using Engine.Core.Driver.Graphics.Buffers;
using Engine.Core.Math.Geometrics;
using Engine.Core.Math.Vectors;
using Engine.OpenGL.Vendor.OpenGL.Core;

namespace Engine.OpenGL.Driver.GraphicsApi.Buffers;

/// <summary>
/// Implementation of <see cref="GlBufferObject" />
/// </summary>
internal sealed class GlBufferObject : IBufferObject
{
    private readonly uint _bufferId;
    private readonly bool _isIndexBuffer;
    private IBufferLayout _layout;

    /// <summary>
    /// Creates a new instance of <see cref="GlBufferObject" />
    /// </summary>
    public GlBufferObject(IBufferLayout layout, bool isIndexBuffer = false)
    {
        _layout = layout;
        _isIndexBuffer = isIndexBuffer;

        if (_bufferId != 0)
        {
            Gl.DeleteBuffer(_bufferId);
        }

        _bufferId = Gl.GenBuffer();
        Gl.CheckError($"{nameof(GlBufferObject)}#Gl.GenBuffer");
    }

    /// <inheritdoc />
    public void SetData(Vertex[] data)
    {
        var bufferData = Enumerable.Empty<float>();

        for (var i = 0; i < data.Length; i++)
        {
            bufferData = bufferData.Concat(data[i].ToFloat());
        }

        // Set data
        Bind();
        Gl.BufferData(
            _isIndexBuffer ? BufferTarget.ElementArrayBuffer : BufferTarget.ArrayBuffer,
            sizeof(float) * data[0].GetComponentCount() * data.Length,
            bufferData.ToArray(),
            BufferUsageHint.StaticDraw);
        Gl.CheckError($"{nameof(GlBufferObject)}#Gl.BufferData");
        Unbind();
    }

    /// <inheritdoc />
    public void SetData(Vector2[] data)
    {
        var bufferData = Enumerable.Empty<float>();

        for (var i = 0; i < data.Length; i++)
        {
            bufferData = bufferData.Concat(new[] { data[i].X, data[i].Y });
        }

        // Set data
        Bind();
        Gl.BufferData(
            _isIndexBuffer ? BufferTarget.ElementArrayBuffer : BufferTarget.ArrayBuffer,
            sizeof(float) * 2 * data.Length,
            bufferData.ToArray(),
            BufferUsageHint.StaticDraw);
        Gl.CheckError($"{nameof(GlBufferObject)}#Gl.BufferData");
        Unbind();
    }

    /// <inheritdoc />
    public void SetData(Vector3[] data)
    {
        var bufferData = Enumerable.Empty<float>();

        for (var i = 0; i < data.Length; i++)
        {
            bufferData = bufferData.Concat(new[] { data[i].X, data[i].Y, data[i].Z });
        }

        // Set data
        Bind();
        Gl.BufferData(
            _isIndexBuffer ? BufferTarget.ElementArrayBuffer : BufferTarget.ArrayBuffer,
            sizeof(float) * 3 * data.Length,
            bufferData.ToArray(),
            BufferUsageHint.StaticDraw);
        Gl.CheckError($"{nameof(GlBufferObject)}#Gl.BufferData");
        Unbind();
    }

    /// <inheritdoc />
    public void SetData(int[] data)
    {
        Bind();
        Gl.BufferData(
            _isIndexBuffer ? BufferTarget.ElementArrayBuffer : BufferTarget.ArrayBuffer,
            sizeof(int) * data.Length,
            data,
            BufferUsageHint.StaticDraw);
        Gl.CheckError($"{nameof(GlBufferObject)}#Gl.BufferData");
        Unbind();
    }

    /// <inheritdoc />
    public void SetData(float[] data)
    {
        Bind();
        Gl.BufferData(
            _isIndexBuffer ? BufferTarget.ElementArrayBuffer : BufferTarget.ArrayBuffer,
            sizeof(float) * data.Length,
            data,
            BufferUsageHint.StaticDraw);
        Gl.CheckError($"{nameof(GlBufferObject)}#Gl.BufferData");
        Unbind();
    }

    /// <inheritdoc />
    public void Bind()
    {
        Gl.BindBuffer(
            _isIndexBuffer
                ? BufferTarget.ElementArrayBuffer
                : BufferTarget.ArrayBuffer,
            _bufferId);
    }

    /// <inheritdoc />
    public void Unbind()
    {
        Gl.BindBuffer(_isIndexBuffer
                ? BufferTarget.ElementArrayBuffer
                : BufferTarget.ArrayBuffer,
            _bufferId);
    }

    /// <inheritdoc />
    public uint GetId()
    {
        return _bufferId;
    }

    /// <inheritdoc />
    public void SetLayout(IBufferLayout layout)
    {
        ArgumentNullException.ThrowIfNull(layout);
        _layout = layout;
    }

    /// <inheritdoc />
    public IBufferLayout GetLayout()
    {
        return _layout;
    }

    /// <inheritdoc />
    void IDisposable.Dispose()
    {
        Gl.DeleteBuffer(_bufferId);
    }
}
