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
        const float radius = 0.5f;
        var positions = new Vector3[segments + 1];

        for (var i = 0; i < segments; i++)
        {
            var theta = 2f * (Mathf.Pi * i) / segments;
            var x = radius + radius * Mathf.Cos(theta);
            var y = radius + radius * Mathf.Sin(theta);
            positions[i] = new Vector3(x - 0.5f, y - 0.5f, 0f);
        }

        positions[segments] = new Vector3(radius - 0.5f, radius - 0.5f, 0);

        var vertices = positions.Select(position => new Vertex(position, Color.White)).ToArray();

        var triangles = new int[segments * 3];
        for (var i = 0; i < segments; i++)
        {
            triangles[i * 3] = segments;
            triangles[i * 3 + 1] = i;
            triangles[i * 3 + 2] = (i + 1) % segments;
        }

        Vertices = vertices;
        Indices = triangles;

        UvCoordinates = positions.Select(x => new Vector2(x.X + .5f, x.Y + .5f)).ToArray();

        Build();
    }
}
