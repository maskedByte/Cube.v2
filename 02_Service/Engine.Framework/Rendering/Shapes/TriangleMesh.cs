using Engine.Core.Driver;
using Engine.Core.Math.Base;
using Engine.Core.Math.Geometrics;
using Engine.Core.Math.Vectors;

namespace Engine.Framework.Rendering.Shapes;

public sealed class TriangleMesh : Mesh
{
    public TriangleMesh(IContext context)
        : base(context)
    {
        Vertices = new[]
        {
            new Vertex(new Vector3(-.5f, -.5f, 0), Color.White),
            new Vertex(new Vector3(0.5f, -.5f, 0), Color.White),
            new Vertex(new Vector3(0f, .5f, 0), Color.White)
        };

        UvCoordinates = new[]
        {
            new Vector2(0f, 0f),
            new Vector2(1f, 0f),
            new Vector2(0.5f, 1f)
        };

        Indices = new[]
        {
            0,
            1,
            2
        };

        Build();
    }
}
