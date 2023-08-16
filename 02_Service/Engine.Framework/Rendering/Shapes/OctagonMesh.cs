using Engine.Core.Driver;
using Engine.Core.Math.Base;
using Engine.Core.Math.Geometrics;
using Engine.Core.Math.Vectors;

namespace Engine.Framework.Rendering.Shapes;

public sealed class OctagonMesh : Mesh
{
    public OctagonMesh(IContext context)
        : base(context)
    {
        const float offset = 0.5f;

        // Set UV if null
        Vertices = new[]
        {
            new Vertex(new Vector3(0.25f - offset, 1.0f - offset, 0), Color.White),
            new Vertex(new Vector3(0.0f - offset, 0.75f - offset, 0), Color.White),
            new Vertex(new Vector3(0.0f - offset, 0.25f - offset, 0), Color.White),
            new Vertex(new Vector3(0.25f - offset, 0.0f - offset, 0), Color.White),
            new Vertex(new Vector3(0.75f - offset, 0.0f - offset, 0), Color.White),
            new Vertex(new Vector3(1.0f - offset, 0.25f - offset, 0), Color.White),
            new Vertex(new Vector3(1.0f - offset, 0.75f - offset, 0), Color.White),
            new Vertex(new Vector3(0.75f - offset, 1.0f - offset, 0), Color.White)
        };

        UvCoordinates = new[]
        {
            new Vector2(0.25f, 1.0f),
            new Vector2(0.0f, 0.75f),
            new Vector2(0.0f, 0.25f),
            new Vector2(0.25f, 0.0f),
            new Vector2(0.75f, 0.0f),
            new Vector2(1.0f, 0.25f),
            new Vector2(1.0f, 0.75f),
            new Vector2(0.75f, 1.0f)
        };

        Indices = new[]
        {
            0,
            1,
            2,
            0,
            2,
            3,
            0,
            3,
            4,
            0,
            4,
            5,
            0,
            5,
            6,
            0,
            6,
            7
        };

        Build();
    }
}
