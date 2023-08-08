using Engine.Driver.Api.Buffers;
using Engine.Driver.Api.Shaders;
using Engine.OpenGL.Vendor.OpenGL.Core;

namespace Engine.OpenGL.Driver.GraphicsApi.Buffers;

/// <summary>
/// Implementation of <see cref="GlBufferArray" />
/// </summary>
internal sealed class GlBufferArray : IBufferArray
{
    private readonly uint _vertexArrayId;
    private uint _index;
    private IBufferObject _indexBuffer;
    private IBufferObject? _normalBuffer;
    private IBufferObject? _uvBuffer;
    private IBufferObject _vertexBuffer;

    /// <summary>
    /// Create new instance of <see cref="IBufferArray" />
    /// </summary>
    public GlBufferArray()
    {
        _vertexArrayId = Gl.GenVertexArray();
        Gl.CheckError($"{nameof(GlBufferArray)}#Gl.GenVertexArray");

        _vertexBuffer = null!;
        _indexBuffer = null!;
        _uvBuffer = null;
        _normalBuffer = null;
    }

    /// <inheritdoc />
    public void AddBuffer(IBufferObject buffer, BufferType bufferType)
    {
        switch (bufferType)
        {
            case BufferType.Vertex:
                _vertexBuffer = buffer;
                break;
            case BufferType.Index:
                _indexBuffer = buffer;
                break;
            case BufferType.Uv:
                _uvBuffer = buffer;
                break;
            case BufferType.Normal:
                _normalBuffer = buffer;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(bufferType), bufferType, null);
        }
    }

    /// <inheritdoc />
    public void Bind()
    {
        Gl.BindVertexArray(_vertexArrayId);
    }

    /// <inheritdoc />
    public void Unbind()
    {
        Gl.BindVertexArray(0);
    }

    /// <inheritdoc />
    public void Build()
    {
        Bind();
        AddElements(_vertexBuffer);
        AddElements(_uvBuffer);
        AddElements(_normalBuffer);
        AddElements(_indexBuffer);
        Unbind();
    }

    /// <inheritdoc />
    public uint GetId()
    {
        return _vertexArrayId;
    }

    /// <inheritdoc />
    public void Dispose()
    {
        Gl.DeleteVertexArrays(1, new[] { _vertexArrayId });
    }

    private VertexAttribPointerType GetPointerDataType(ShaderDataType type)
    {
        return type switch
        {
            ShaderDataType.Float => VertexAttribPointerType.Float,
            ShaderDataType.Vector2 => VertexAttribPointerType.Float,
            ShaderDataType.Vector3 => VertexAttribPointerType.Float,
            ShaderDataType.Vector4 => VertexAttribPointerType.Float,
            ShaderDataType.Matrix3 => VertexAttribPointerType.Float,
            ShaderDataType.Matrix4 => VertexAttribPointerType.Float,
            ShaderDataType.Int => VertexAttribPointerType.Int,
            ShaderDataType.Int2 => VertexAttribPointerType.Int,
            ShaderDataType.Int3 => VertexAttribPointerType.Int,
            ShaderDataType.Int4 => VertexAttribPointerType.Int,
            ShaderDataType.Bool => VertexAttribPointerType.Byte,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private void AddElements(IBufferObject? buffer)
    {
        if (buffer == null)
        {
            return;
        }

        buffer.Bind();
        var bufferLayout = buffer.GetLayout();
        foreach (var bufferElement in bufferLayout.GetElements())
        {
            Gl.EnableVertexAttribArray(_index);
            Gl.CheckError($"{nameof(GlBufferArray)}#Gl.BufferData");

            Gl.VertexAttribPointer(
                _index,
                bufferElement.GetElementSize(),
                GetPointerDataType(bufferElement.Type),
                bufferElement.Normalized,
                bufferLayout.GetStride(),
                bufferElement.Offset);
            Gl.CheckError($"{nameof(GlBufferArray)}#Gl.BufferData");

            _index++;
        }

        buffer.Unbind();
    }
}
