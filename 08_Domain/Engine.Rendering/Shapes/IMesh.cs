using Engine.Core.Math.Geometrics;
using Engine.Core.Math.Vectors;

namespace Engine.Rendering.Shapes;

/// <summary>
///     Interface for an 3d object containing vertices, indices, uv coordinates and normals.
/// </summary>
public interface IMesh : IPrimitive, IEquatable<IMesh>
{
    /// <summary>
    ///     The unique id of this mesh
    /// </summary>
    Guid Id { get; }

    /// <summary>
    ///     Define the vertices for this mesh
    /// </summary>
    Vertex[] Vertices { get; set; }

    /// <summary>
    ///     Define the triangles for this mesh
    /// </summary>
    int[] Indices { get; set; }

    /// <summary>
    ///     Returns the number of indices
    /// </summary>
    uint IndexCount { get; }

    /// <summary>
    ///     Define the uv coordinates for this mesh
    /// </summary>
    Vector2[] UvCoordinates { get; set; }

    /// <summary>
    ///     Define the normals for this mesh
    /// </summary>
    Vector3[] Normals { get; set; }

    /// <summary>
    ///     Build the mesh and calculate the normals if not provided
    /// </summary>
    void Build();
}
