using Engine.Core.Driver;
using Engine.Core.Math.Base;
using Engine.Core.Math.Geometrics;
using Engine.Core.Math.Vectors;

namespace Engine.Framework.Rendering.Shapes;

public sealed class CubeMesh : Mesh
{
    public CubeMesh(IContext context)
        : base(context)
    {
        var vertices = new List<Vertex>();
        var indices = new List<int>();

        var halfSize = 0.5f;

        // Vertices
        var cornerVertices = new[]
        {
            new Vertex(new Vector3(-halfSize, -halfSize, -halfSize), Color.White),
            new Vertex(new Vector3(-halfSize, halfSize, -halfSize), Color.White),
            new Vertex(new Vector3(halfSize, halfSize, -halfSize), Color.White),
            new Vertex(new Vector3(halfSize, -halfSize, -halfSize), Color.White),
            new Vertex(new Vector3(-halfSize, -halfSize, halfSize), Color.White),
            new Vertex(new Vector3(-halfSize, halfSize, halfSize), Color.White),
            new Vertex(new Vector3(halfSize, halfSize, halfSize), Color.White),
            new Vertex(new Vector3(halfSize, -halfSize, halfSize), Color.White)
        };

        var faceVertices = new[]
        {
            cornerVertices[0],
            cornerVertices[1],
            cornerVertices[2],
            cornerVertices[3], // Front

            cornerVertices[7],
            cornerVertices[6],
            cornerVertices[5],
            cornerVertices[4], // Back

            cornerVertices[1],
            cornerVertices[0],
            cornerVertices[4],
            cornerVertices[5], // Left

            cornerVertices[2],
            cornerVertices[1],
            cornerVertices[5],
            cornerVertices[6], // Right

            cornerVertices[3],
            cornerVertices[2],
            cornerVertices[6],
            cornerVertices[7], // Top

            cornerVertices[0],
            cornerVertices[3],
            cornerVertices[7],
            cornerVertices[4] // Bottom
        };

        vertices.AddRange(faceVertices.Reverse()); // Reversed for CCW order
        Vertices = vertices.ToArray();

        for (var i = 0; i < faceVertices.Length; i += 4)
        {
            indices.Add(i);
            indices.Add(i + 2);
            indices.Add(i + 1);
            indices.Add(i + 2);
            indices.Add(i);
            indices.Add(i + 3);
        }

        Indices = indices.ToArray();

        UvCoordinates = new[]
        {
            new Vector2(0.0f, 0.0f),
            new Vector2(0.0f, 1.0f),
            new Vector2(1.0f, 1.0f),
            new Vector2(1.0f, 0.0f),
            new Vector2(0.0f, 0.0f),
            new Vector2(0.0f, 1.0f),
            new Vector2(1.0f, 1.0f),
            new Vector2(1.0f, 0.0f),
            new Vector2(0.0f, 0.0f),
            new Vector2(0.0f, 1.0f),
            new Vector2(1.0f, 1.0f),
            new Vector2(1.0f, 0.0f),
            new Vector2(0.0f, 0.0f),
            new Vector2(0.0f, 1.0f),
            new Vector2(1.0f, 1.0f),
            new Vector2(1.0f, 0.0f),
            new Vector2(0.0f, 0.0f),
            new Vector2(0.0f, 1.0f),
            new Vector2(1.0f, 1.0f),
            new Vector2(1.0f, 0.0f),
            new Vector2(0.0f, 0.0f),
            new Vector2(0.0f, 1.0f),
            new Vector2(1.0f, 1.0f),
            new Vector2(1.0f, 0.0f),
            new Vector2(0.0f, 0.0f),
            new Vector2(0.0f, 1.0f),
            new Vector2(1.0f, 1.0f),
            new Vector2(1.0f, 0.0f)
        };

        CalculateNormals();

        Build();
    }
}
