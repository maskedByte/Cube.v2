namespace Engine.Core.Driver;

/// <summary>
///     Enum for different draw modes
/// </summary>
public enum PrimitiveType
{
    Points = 0x000100,
    Lines,
    LineLoop,
    LineStrip,
    Triangles,
    TriangleStrip,
    TriangleFan,
    Quads,
    Polygon
}
