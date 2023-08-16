using Engine.Core.Driver;
using Engine.Core.Math;
using Engine.Core.Math.Base;
using Engine.Core.Math.Geometrics;
using Engine.Core.Math.Vectors;

namespace Engine.Framework.Rendering.Shapes;

public sealed class CircleMesh : Mesh
{
    public CircleMesh(IContext context)
        : this(context, 64)
    {
    }

    public CircleMesh(IContext context, int segments)
        : base(context)
    {
        // Calculate positions
        const float radius = 0.5f;
        var positionsList = new List<Vector3>
        {
            new(radius - 0.5f, radius - 0.5f, 0)
        };

        for (var i = 0; i < segments; i++)
        {
            var theta = 2f * (Mathf.Pi * i) / segments;
            var x = radius + radius * Mathf.Cos(theta);
            var y = radius + radius * Mathf.Sin(theta);
            positionsList.Add(new Vector3(x - 0.5f, y - 0.5f, 0f));
        }

        // Set UV if null
        segments++;
        var positions = positionsList.ToArray();

        var uvData = new Vector3[segments + 1];
        Array.Copy(positions, uvData, positions.Length);

        var vertices = new Vertex[segments + 1];
        for (var i = 0; i < segments; i++)
        {
            vertices[i] = new Vertex(positions[i], Color.White);
        }

        var triangles = new List<int>();
        int triCount;
        for (triCount = 0; triCount < segments - 2; triCount++)
        {
            triangles.Add(0);
            triangles.Add(triCount + 1);
            triangles.Add(triCount + 2);
        }

        // Add triangle to connect last and first indices
        triangles.Add(0);
        triangles.Add(segments - 1);
        triangles.Add(1);

        Vertices = vertices;
        Indices = triangles.ToArray();

        UvCoordinates = uvData.Select(x => new Vector2(x.X + .5f, x.Y + .5f)).ToArray();

        Build();
    }
}
