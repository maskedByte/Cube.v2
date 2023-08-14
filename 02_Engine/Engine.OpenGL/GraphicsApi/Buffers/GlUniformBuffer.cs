using Engine.Core.Driver.Graphics.Buffers;
using Engine.Core.Driver.Graphics.Shaders;
using Engine.Core.Math.Base;
using Engine.Core.Math.Matrices;
using Engine.Core.Math.Vectors;
using Engine.Core.Memory.Pinning;
using Engine.OpenGL.Vendor.OpenGL.Core;

namespace Engine.OpenGL.GraphicsApi.Buffers;

/// <summary>
///     Create a new <see cref="IUniformBuffer" />
/// </summary>
internal sealed class GlUniformBuffer : IUniformBuffer
{
    private readonly List<uint> _attachedShader;
    private readonly uint _blockBindingId;
    private readonly uint _bufferId;
    private readonly IBufferLayout _bufferLayout;
    private readonly string _name;

    private readonly PinnedStructures _pinnedStructures;

    /// <summary>
    ///     Create new <see cref="GlUniformBuffer" />
    /// </summary>
    /// <param name="name">Set a unique identifier for this <see cref="GlUniformBuffer" /></param>
    /// <param name="bufferLayout">
    ///     The <see cref="BufferLayout" /> are used for calculate the size and to set the structure of
    ///     the buffer.
    /// </param>
    /// <param name="blockBindingId"></param>
    /// <exception cref="ArgumentNullException">If name was not set</exception>
    public GlUniformBuffer(string name, IBufferLayout bufferLayout, uint blockBindingId)
    {
        _name = name ?? throw new ArgumentNullException(nameof(name));
        _bufferLayout = bufferLayout;
        _blockBindingId = blockBindingId;
        _attachedShader = new List<uint>();

        _pinnedStructures = new PinnedStructures();
        _pinnedStructures.Add<float>();
        _pinnedStructures.Add<Vector2>();
        _pinnedStructures.Add<Vector3>();
        _pinnedStructures.Add<Vector4>();
        _pinnedStructures.Add<Color>();
        _pinnedStructures.Add<Matrix2>();
        _pinnedStructures.Add<Matrix3>();
        _pinnedStructures.Add<Matrix4>();

        _bufferId = Gl.GenBuffer();
        Gl.CheckError($"{nameof(GlUniformBuffer)}#Gl.GenBuffer");

        Bind();
        Gl.BufferData(
            BufferTarget.UniformBuffer,
            _bufferLayout.GetStride(),
            (nint)null,
            BufferUsageHint.DynamicDraw
        );
        Gl.CheckError($"{nameof(GlUniformBuffer)}#Gl.BufferData");
        Unbind();

        Gl.BindBufferRange(
            BufferTarget.UniformBuffer,
            blockBindingId,
            _bufferId,
            nint.Zero,
            _bufferLayout.GetStride()
        );
        Gl.CheckError($"{nameof(GlUniformBuffer)}#Gl.BindBufferRange");
    }

    /// <inheritdoc />
    public void Bind() => GlStateWatch.BindBuffer(BufferTarget.UniformBuffer, _bufferId);

    /// <inheritdoc />
    public void Unbind() => GlStateWatch.UnbindBuffer(BufferTarget.UniformBuffer);

    /// <inheritdoc />
    public void Attach(IShaderProgram shaderProgram)
    {
        ArgumentNullException.ThrowIfNull(shaderProgram);
        var shaderId = shaderProgram.GetId();

        if (_attachedShader.Contains(shaderId))
        {
            return;
        }

        if (shaderProgram.GetProgramState() != ShaderProgramState.Compiled)
        {
            shaderProgram.Compile();
        }

        var blockId = Gl.GetUniformBlockIndex(shaderId, _name);
        Gl.CheckError($"{nameof(GlUniformBuffer)}#Gl.GetUniformBlockIndex");

        Gl.UniformBlockBinding(shaderId, blockId, _blockBindingId);
        Gl.CheckError($"{nameof(GlUniformBuffer)}#Gl.UniformBlockBinding");

        _attachedShader.Add(shaderId);
    }

    /// <inheritdoc />
    public void SetUniformData(string name, float value)
    {
        var structure = _pinnedStructures.Get<float>();
        structure.Set(value);
        SetBufferData(_bufferLayout[name], structure);
    }

    /// <inheritdoc />
    public void SetUniformData(string name, Vector2 value)
    {
        var structure = _pinnedStructures.Get<Vector2>();
        structure.Set(value);
        SetBufferData(_bufferLayout[name], structure);
    }

    /// <inheritdoc />
    public void SetUniformData(string name, Vector3 value)
    {
        var structure = _pinnedStructures.Get<Vector3>();
        structure.Set(value);
        SetBufferData(_bufferLayout[name], structure);
    }

    /// <inheritdoc />
    public void SetUniformData(string name, Vector4 value)
    {
        var structure = _pinnedStructures.Get<Vector4>();
        structure.Set(value);
        SetBufferData(_bufferLayout[name], structure);
    }

    /// <inheritdoc />
    public void SetUniformData(string name, Color value) => SetUniformData(name, value.ToVector4());

    /// <inheritdoc />
    public void SetUniformData(string name, Matrix2 value)
    {
        var structure = _pinnedStructures.Get<Matrix2>();
        structure.Set(value);
        SetBufferData(_bufferLayout[name], structure);
    }

    /// <inheritdoc />
    public void SetUniformData(string name, Matrix3 value)
    {
        var structure = _pinnedStructures.Get<Matrix3>();
        structure.Set(value);
        SetBufferData(_bufferLayout[name], structure);
    }

    /// <inheritdoc />
    public void SetUniformData(string name, Matrix4 value)
    {
        var structure = _pinnedStructures.Get<Matrix4>();
        structure.Set(value);
        SetBufferData(_bufferLayout[name], structure);
    }

    /// <inheritdoc />
    public void Dispose()
    {
        Gl.DeleteBuffer(_bufferId);
        _pinnedStructures.Free();
    }

    /// <inheritdoc />
    public uint GetId() => _bufferId;

    private void SetBufferData<T>(BufferElement element, IPinnedStructure<T> pinnedStructure)
    {
        Bind();
        Gl.BufferSubData(BufferTarget.UniformBuffer, element.Offset, element.Size, pinnedStructure.Address);
    }
}
