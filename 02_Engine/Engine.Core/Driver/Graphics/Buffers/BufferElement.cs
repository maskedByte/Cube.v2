using Engine.Core.Driver.Graphics.Shaders;

namespace Engine.Core.Driver.Graphics.Buffers;

/// <summary>
/// <see cref="BufferElement" /> struct implementation
/// </summary>
public sealed class BufferElement
{
    /// <summary>
    /// Defines the index of the layout location
    /// </summary>
    public uint Index { get; }

    /// <summary>
    /// Name of the <see cref="BufferElement" />
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Offset of the <see cref="BufferElement" />
    /// </summary>
    public int Offset { get; set; }

    /// <summary>
    /// Size of the <see cref="BufferElement" /> in bytes
    /// </summary>
    public int Size { get; }

    /// <summary>
    /// Shader data type of the <see cref="BufferElement" />
    /// </summary>
    public ShaderDataType Type { get; }

    /// <summary>
    /// Get or set normalized to true/false if data is normalized
    /// </summary>
    public bool Normalized { get; }

    /// <summary>
    /// Creates a new instance of <see cref="BufferElement" />
    /// </summary>
    /// <param name="index">The index for the shader layout location</param>
    /// <param name="name">The name of the shader element</param>
    /// <param name="type">The type of the shader element</param>
    public BufferElement(uint index, string name, ShaderDataType type)
    {
        Index = index;
        Name = name;
        Type = type;
        Size = 0;
        Offset = 0;
        Normalized = false;

        Size = GetShaderDataTypeSize(type);
    }

    /// <summary>
    /// Gets the correct size for Shader data types
    /// </summary>
    /// <returns>Size for the data in bytes</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public int GetShaderDataTypeSize(ShaderDataType type)
    {
        return Type switch
        {
            ShaderDataType.None => 0,
            ShaderDataType.Float => 4,
            ShaderDataType.Vector2 => 8,
            ShaderDataType.Vector3 => 12,
            ShaderDataType.Vector4 => 16,
            ShaderDataType.Matrix3 => 36,
            ShaderDataType.Matrix4 => 64,
            ShaderDataType.Int => 4,
            ShaderDataType.Int2 => 8,
            ShaderDataType.Int3 => 12,
            ShaderDataType.Int4 => 16,
            ShaderDataType.Bool => 1,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    /// <summary>
    /// Returns the specific size for an element
    /// </summary>
    /// <returns>size of the element</returns>
    public int GetElementSize()
    {
        return Type switch
        {
            ShaderDataType.Float => 1,
            ShaderDataType.Vector2 => 2,
            ShaderDataType.Vector3 => 3,
            ShaderDataType.Vector4 => 4,
            ShaderDataType.Matrix3 => 9,
            ShaderDataType.Matrix4 => 16,
            ShaderDataType.Int => 1,
            ShaderDataType.Int2 => 2,
            ShaderDataType.Int3 => 3,
            ShaderDataType.Int4 => 4,
            ShaderDataType.Bool => 1,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
