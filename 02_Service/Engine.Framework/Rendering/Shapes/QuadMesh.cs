using Engine.Core.Driver;
using Engine.Core.Math.Base;
using Engine.Core.Math.Geometrics;
using Engine.Core.Math.Vectors;

namespace Engine.Framework.Rendering.Shapes;

public sealed class QuadMesh : Mesh
{
    public QuadMesh(IContext context)
        : base(context)

    {
        Vertices = new[]
        {
            new Vertex(new Vector3(-.5f, -.5f, 0f), Color.White),
            new Vertex(new Vector3(.5f, -.5f, 0f), Color.White),
            new Vertex(new Vector3(.5f, .5f, 0f), Color.White),
            new Vertex(new Vector3(-.5f, .5f, 0f), Color.White)
        };

        UvCoordinates = new[]
        {
            new Vector2(0f, 0f),
            new Vector2(1f, 0f),
            new Vector2(1f, 1f),
            new Vector2(0f, 1f)
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

        Normals = new Vector3[4];

        for (var i = 0; i < 4; i++)
        {
            Normals[i] = new Vector3(0, 0, 1);
        }

        Build();
    }
}
