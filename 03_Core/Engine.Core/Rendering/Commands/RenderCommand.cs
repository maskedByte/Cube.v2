using Engine.Core.Driver;
using Engine.Core.Driver.Graphics.Buffers;
using Engine.Core.Driver.Graphics.Shaders;
using Engine.Core.Driver.Graphics.Textures;

namespace Engine.Core.Rendering.Commands;

/// <summary>
///     Structure representing a render command
/// </summary>
public class RenderCommand : ICommand
{
    /// <summary>
    ///     The unique id of the render command
    /// </summary>
    public Guid Id { get; } = new();

    /// <summary>
    ///     Gets or sets the priority of the render command.
    /// </summary>
    public int Priority { get; init; }

    /// <summary>
    ///     Gets or sets the type of the render command.
    /// </summary>
    public required CommandType Type { get; init; }

    /// <summary>
    ///     Gets or sets the number of vertices in the render command.
    /// </summary>
    public required int VertexCount { get; init; }

    /// <summary>
    ///     Gets or sets the number of indices in the render command.
    /// </summary>
    public required int IndexCount { get; init; }

    /// <summary>
    ///     Gets or sets the array of uniform buffers associated with the render command.
    /// </summary>
    public required IUniformBuffer[] UniformBuffers { get; init; }

    /// <summary>
    ///     Gets or sets the array of textures associated with the render command.
    /// </summary>
    public required ITexture[] Textures { get; init; }

    /// <summary>
    ///     Gets or sets the buffer array associated with the render command.
    /// </summary>
    public required IBufferArray BufferArray { get; init; }

    /// <summary>
    ///     Gets or sets the primitive type used for rendering.
    /// </summary>
    public required PrimitiveType PrimitiveType { get; init; }

    /// <summary>
    ///     Gets or sets the shader used for rendering.
    /// </summary>
    public required IShader Shader { get; init; }

    public ITexture[] Input { get; init; }

    /// <summary>
    ///     Gets or sets the base index offset for indexed rendering.
    /// </summary>
    public int BaseIndex { get; init; } = 0;

    /// <summary>
    ///     Gets or sets the base vertex offset for rendering.
    /// </summary>
    public int BaseVertex { get; init; } = 0;

    /// <summary>
    ///     Default constructor
    /// </summary>
    public RenderCommand()
    {
        Priority = 0;
        Type = CommandType.NullRenderCommand;
        VertexCount = 0;
        IndexCount = 0;
        UniformBuffers = Array.Empty<IUniformBuffer>();
        Textures = Array.Empty<ITexture>();
        PrimitiveType = PrimitiveType.Triangles;
        Input = Array.Empty<ITexture>();
    }
}
