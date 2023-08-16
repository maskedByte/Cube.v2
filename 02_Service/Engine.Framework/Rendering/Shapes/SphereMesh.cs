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
        // Create the vertex data for the sphere
        var vertices = new List<Vertex>();
        var uvs = new List<Vector2>();
        for (var lat = 0; lat <= latitudeBands; lat++)
        {
            var theta = lat * Mathf.Pi / latitudeBands;
            var sinTheta = Mathf.Sin(theta);
            var cosTheta = Mathf.Cos(theta);

            for (var lon = 0; lon <= longitudeBands; lon++)
            {
                var phi = (float)lon * 2 * Mathf.Pi / longitudeBands;
                var sinPhi = Mathf.Sin(phi);
                var cosPhi = Mathf.Cos(phi);

                var normal = new Vector3(.5f * cosPhi * sinTheta, .5f * cosTheta, .5f * sinPhi * sinTheta);
                vertices.Add(new Vertex(normal, Color.White));
                uvs.Add(new Vector2((float)lon / longitudeBands, 1f - (float)lat / latitudeBands));
            }
        }

        // Create the index data for the sphere
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

        // Set the properties of the Mesh object
        Vertices = vertices.ToArray();
        Indices = indices.ToArray();
        UvCoordinates = uvs.ToArray();

        // this.Normals = vertices.Select<>(v => v.Normal).ToArray();
        Center = CalculateLeastSquaresCenter();

        Build();
    }

    private Vector4 CalculateAverage()
    {
        var average = new Vector4(0);
        average = Vertices.Aggregate(average, (current, vertex) => current + vertex.Position);
        return average / Vertices.Length;
    }

    private double CalculateSquaredDistance(Vector4 vertex, Vector4 averageCenter) =>
        Mathf.Pow(vertex.X - averageCenter.X, 2) + Mathf.Pow(vertex.Y - averageCenter.Y, 2) + Mathf.Pow(vertex.Z - averageCenter.Z, 2);

    private Vector4 CalculateAverageOfClosestVertices(Vector4 currentCenter)
    {
        var minSquaredDistance = double.MaxValue;
        var closestVertex = new Vector4();

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
        var previousCenter = new Vector4(0);

        while (currentCenter != previousCenter)
        {
            previousCenter = currentCenter;
            currentCenter = CalculateAverageOfClosestVertices(currentCenter);
        }

        return currentCenter.Xyz;
    }
}
