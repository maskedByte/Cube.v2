using Engine.Core.Driver.Graphics.Buffers;

namespace Engine.Rendering.Shapes;

/// <summary>
///     Interface for 3d primitive objects like cube, sphere, cylinder ...
/// </summary>
public interface IPrimitive
{
    /// <summary>
    ///     The buffer array containing all vertices, indices, uv's etc.
    /// </summary>
    IBufferArray BufferArray { get; set; }
}
