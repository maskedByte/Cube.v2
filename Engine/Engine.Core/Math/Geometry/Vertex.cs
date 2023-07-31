using System.Runtime.InteropServices;
using Engine.Math.Core;
using Engine.Math.Vector;

namespace Engine.Math.Geometry;

/// <summary>
/// Struct implementation for a Vertex
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly struct Vertex
{
    /// <summary>
    /// Position of the vertex
    /// </summary>
    public Vector4 Position { get; }

    /// <summary>
    /// Color of the vertex
    /// </summary>
    public Color? Color { get; }

    /// <summary>
    /// Construct the vertex from its position, color and texture coordinates
    /// </summary>
    /// <param name="position">Vertex position</param>
    /// <param name="color">set the color for this vertex</param>
    public Vertex(Vector3 position, Color? color = null)
    {
        Position = new Vector4(position, 1f);
        Color = color;
    }

    /// <summary>
    /// Returns the count of set elements 3 => Position + if set 4 for color etc ...
    /// </summary>
    public int GetComponentCount()
    {
        return Color == null ? 4 : 8;
    }

    /// <summary>
    /// Return the Vertex as float[] containing all available data
    /// </summary>
    public IEnumerable<float> ToFloat()
    {
        var length = GetComponentCount();
        var result = new float[length];

        result[0] = Position.X;
        result[1] = Position.Y;
        result[2] = Position.Z;
        result[3] = Position.W;

        if (Color == null) return result;

        var color = Color!.ToVector4();
        result[4] = color.X;
        result[5] = color.Y;
        result[6] = color.Z;
        result[7] = color.W;

        return result;
    }

    /// <summary>
    /// Returns the values set for this <see cref="Vertex"/>
    /// </summary>
    public override string ToString()
    {
        return $"[Vertex] Position({Position}) Color({Color}))";
    }
}
