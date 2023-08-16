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
        Vertices = new[]
        {
            new Vertex(new Vector3(0, 0, 0), Color.White), // 0 Front Side
            new Vertex(new Vector3(0, 1, 0), Color.White), // 1 Front Side
            new Vertex(new Vector3(1, 1, 0), Color.White), // 2 Front Side
            new Vertex(new Vector3(1, 0, 0), Color.White), // 3 Front Side

            new Vertex(new Vector3(1, 0, 0), Color.White), // 4 Right Side
            new Vertex(new Vector3(1, 1, 0), Color.White), // 5 Right Side
            new Vertex(new Vector3(1, 1, 1), Color.White), // 6 Right Side
            new Vertex(new Vector3(1, 0, 1), Color.White), // 7 Right Side

            new Vertex(new Vector3(0, 0, 1), Color.White), // 8 Left Side
            new Vertex(new Vector3(0, 1, 1), Color.White), // 9 Left Side
            new Vertex(new Vector3(0, 1, 0), Color.White), // 10 Left Side
            new Vertex(new Vector3(0, 0, 0), Color.White), // 11 Left Side

            new Vertex(new Vector3(1, 0, 1), Color.White), // 12 Back Side
            new Vertex(new Vector3(1, 1, 1), Color.White), // 13 Back Side
            new Vertex(new Vector3(0, 1, 1), Color.White), // 14 Back Side
            new Vertex(new Vector3(0, 0, 1), Color.White), // 15 Back Side

            new Vertex(new Vector3(0, 1, 0), Color.White), // 16 Up Side
            new Vertex(new Vector3(0, 1, 1), Color.White), // 17 Up Side
            new Vertex(new Vector3(1, 1, 1), Color.White), // 18 Up Side
            new Vertex(new Vector3(1, 1, 0), Color.White), // 19 Up Side

            new Vertex(new Vector3(0, 0, 1), Color.White), // 20 Down Side
            new Vertex(new Vector3(0, 0, 0), Color.White), // 21 Down Side
            new Vertex(new Vector3(1, 0, 0), Color.White), // 22 Down Side
            new Vertex(new Vector3(1, 0, 1), Color.White) // 23 Down Side
        };

        Indices = new[]
        {
            // Front
            1,
            2,
            0,
            2,
            3,
            0,

            // Right
            4,
            5,
            6,
            6,
            7,
            4,

            // Left
            8,
            9,
            10,
            10,
            11,
            8,

            // Back
            12,
            13,
            14,
            14,
            15,
            12,

            // Top
            16,
            17,
            18,
            18,
            19,
            16,

            // Bottom
            20,
            21,
            22,
            22,
            23,
            20
        };

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

        Build();
    }
}
