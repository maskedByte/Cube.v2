using Engine.Core.Driver;
using Engine.Core.Math.Base;
using Engine.Core.Math.Geometrics;
using Engine.Core.Math.Vectors;

namespace Engine.Framework.Rendering.Shapes;

public class RectMesh : Mesh
{
    public RectMesh(IContext context)
        : base(context)

    {
        Vertices = new[]
        {
            new Vertex(new Vector3(0f, 0f, 0f), Color.White),
            new Vertex(new Vector3(1f, 0f, 0f), Color.White),
            new Vertex(new Vector3(1f, 1f, 0f), Color.White),
            new Vertex(new Vector3(0f, 1f, 0f), Color.White)
        };

        UvCoordinates = new[]
        {
            new Vector2(0f, 1f),
            new Vector2(1f, 1f),
            new Vector2(1f, 0f),
            new Vector2(0f, 0f)
        };

        Indices = new[]
        {
            0,
            1,
            2,
            0,
            2,
            3
        };

        Build();
    }
}
