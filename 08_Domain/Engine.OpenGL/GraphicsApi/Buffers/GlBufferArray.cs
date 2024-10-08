using Engine.Core.Driver.Graphics.Buffers;
using Engine.Core.Driver.Graphics.Shaders;
using Engine.Core.Logging;
using Engine.OpenGL.Vendor.OpenGL.Core;

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

namespace Engine.OpenGL.GraphicsApi.Buffers;

/// <summary>
///     Implementation of <see cref="GlBufferArray" />
/// </summary>
internal sealed class GlBufferArray : IBufferArray
{
    private readonly Dictionary<BufferType, IBufferObject?> _bufferObjects;
    private readonly uint _vertexArrayObjectId;

    /// <summary>
    ///     Create new instance of <see cref="IBufferArray" />
    /// </summary>
    public GlBufferArray()
    {
        _vertexArrayObjectId = Gl.GenVertexArray();
        Gl.CheckError($"{nameof(GlBufferArray)}#Gl.GenVertexArray");

        _bufferObjects = new Dictionary<BufferType, IBufferObject?>();
    }

    /// <inheritdoc />
    public uint GetId() => _vertexArrayObjectId;

    /// <inheritdoc />
    public void AddBuffer(IBufferObject buffer, BufferType bufferType) => _bufferObjects.Add(bufferType, buffer);

    /// <inheritdoc />
    public void Bind() => GlStateWatch.BindBufferArray(this);

    /// <inheritdoc />
    public void Unbind() => GlStateWatch.UnbindBufferArray();

    /// <inheritdoc />
    public void Build()
    {
        if (!_bufferObjects.Any())
        {
            Log.LogMessageAsync("No buffer objects to build", LogLevel.Warning, this);
            return;
        }

        Bind();
        foreach (var (bufferType, bufferObject) in _bufferObjects)
        {
            if (bufferObject == null)
            {
                continue;
            }

            bufferObject.Bind();
            AddElements(bufferObject);
            if (bufferType != BufferType.Index)
            {
                bufferObject.Unbind();
            }
        }

        Unbind();
    }

    /// <inheritdoc />
    public void Dispose() =>
        Gl.DeleteVertexArrays(
            1,
            new[]
            {
                _vertexArrayObjectId
            }
        );

    private static void AddElements(IBufferObject? buffer)
    {
        if (buffer == null)
        {
            return;
        }

        var bufferLayout = buffer.GetLayout();
        foreach (var bufferElement in bufferLayout.GetElements())
        {
            Gl.EnableVertexAttribArray(bufferElement.Index);
            Gl.CheckError($"{nameof(GlBufferArray)}#Gl.BufferData");

            Gl.VertexAttribPointer(
                bufferElement.Index,
                bufferElement.GetElementSize(),
                GetPointerDataType(bufferElement.Type),
                bufferElement.Normalized,
                bufferLayout.GetStride(),
                bufferElement.Offset
            );
            Gl.CheckError($"{nameof(GlBufferArray)}#Gl.BufferData");
        }
    }

    private static VertexAttribPointerType GetPointerDataType(ShaderDataType type) =>
        type switch
        {
            ShaderDataType.Float   => VertexAttribPointerType.Float,
            ShaderDataType.Vector2 => VertexAttribPointerType.Float,
            ShaderDataType.Vector3 => VertexAttribPointerType.Float,
            ShaderDataType.Vector4 => VertexAttribPointerType.Float,
            ShaderDataType.Matrix3 => VertexAttribPointerType.Float,
            ShaderDataType.Matrix4 => VertexAttribPointerType.Float,
            ShaderDataType.Int     => VertexAttribPointerType.Int,
            ShaderDataType.Int2    => VertexAttribPointerType.Int,
            ShaderDataType.Int3    => VertexAttribPointerType.Int,
            ShaderDataType.Int4    => VertexAttribPointerType.Int,
            ShaderDataType.Bool    => VertexAttribPointerType.Byte,
            _                      => throw new ArgumentOutOfRangeException()
        };
}
