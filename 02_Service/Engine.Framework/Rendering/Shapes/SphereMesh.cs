using Engine.Core.Driver;
using Engine.Core.Math;
using Engine.Core.Math.Base;
using Engine.Core.Math.Geometrics;
using Engine.Core.Math.Vectors;

namespace Engine.Framework.Rendering.Shapes;

public sealed class SphereMesh : Mesh
{
    public Vector3 Center { get; private set; }

    public SphereMesh(IContext context, int latitudeBands = 15, int longitudeBands = 15)
        : base(context)
    {
        var vertices = new List<Vertex>();
        var uvs = new List<Vector2>();

        for (var lat = 0; lat <= latitudeBands; lat++)
        {
            var theta = lat * Mathf.Pi / latitudeBands;
            var sinTheta = Mathf.Sin(theta);
            var cosTheta = Mathf.Cos(theta);

            for (var lon = 0; lon <= longitudeBands; lon++)
            {
                var phi = lon * 2f * Mathf.Pi / longitudeBands;
                var sinPhi = Mathf.Sin(phi);
                var cosPhi = Mathf.Cos(phi);

                var normal = new Vector4(cosPhi * sinTheta, cosTheta, sinPhi * sinTheta, 1.0f);
                vertices.Add(new Vertex(normal.Xyz * 0.5f, Color.White));
                uvs.Add(new Vector2(lon / (float)longitudeBands, 1f - lat / (float)latitudeBands));
            }
        }

        var indices = new List<int>();
        for (var lat = 0; lat < latitudeBands; lat++)
        {
            for (var lon = 0; lon < longitudeBands; lon++)
            {
                var first = lat * (longitudeBands + 1) + lon;
                var second = first + longitudeBands + 1;

                indices.Add(first + 1);
                indices.Add(second);
                indices.Add(first);

                indices.Add(first + 1);
                indices.Add(second + 1);
                indices.Add(second);
            }
        }

        Vertices = vertices.ToArray();
        Indices = indices.ToArray();
        UvCoordinates = uvs.ToArray();

        Center = CalculateLeastSquaresCenter();

        Build();
    }

    private Vector4 CalculateAverage()
    {
        var sum = Vector4.Zero;
        foreach (var vertex in Vertices)
        {
            sum += vertex.Position;
        }

        return sum / Vertices.Length;
    }

    private float CalculateSquaredDistance(Vector4 vertex, Vector4 averageCenter) =>
        Vector4.Dot(vertex - averageCenter, vertex - averageCenter);

    private Vector4 CalculateAverageOfClosestVertices(Vector4 currentCenter)
    {
        var minSquaredDistance = float.MaxValue;
        var closestVertex = Vector4.Zero;

        foreach (var vertex in Vertices)
        {
            var squaredDistance = CalculateSquaredDistance(vertex.Position, currentCenter);
            if (squaredDistance < minSquaredDistance)
            {
                minSquaredDistance = squaredDistance;
                closestVertex = vertex.Position;
            }
        }

        return closestVertex;
    }

    private Vector3 CalculateLeastSquaresCenter()
    {
        var currentCenter = CalculateAverage();
        var previousCenter = Vector4.Zero;

        while (currentCenter != previousCenter)
        {
            previousCenter = currentCenter;
            currentCenter = CalculateAverageOfClosestVertices(currentCenter);
        }

        return currentCenter.Xyz;
    }

}
