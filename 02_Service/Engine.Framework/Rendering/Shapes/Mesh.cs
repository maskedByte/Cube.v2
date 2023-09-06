using Engine.Core.Driver;
using Engine.Core.Driver.Graphics.Buffers;
using Engine.Core.Driver.Graphics.Shaders;
using Engine.Core.Math.Geometrics;
using Engine.Core.Math.Vectors;
using Engine.Rendering.Shapes;

namespace Engine.Framework.Rendering.Shapes;

public abstract class Mesh : IMesh
{
    private readonly IContext _context;
    private bool _builded;

    /// <inheritdoc />
    public Guid Id { get; }

    /// <inheritdoc />
    public IBufferArray BufferArray { get; set; } = null!;

    /// <inheritdoc />
    public Vertex[] Vertices { get; set; } = Array.Empty<Vertex>();

    /// <inheritdoc />
    public int[] Indices { get; set; } = Array.Empty<int>();

    /// <inheritdoc />
    public uint IndexCount => (uint)Indices.Length;

    /// <inheritdoc />
    public Vector2[] UvCoordinates { get; set; } = Array.Empty<Vector2>();

    /// <inheritdoc />
    public Vector3[] Normals { get; set; } = Array.Empty<Vector3>();

    /// <summary>
    ///     Default constructor
    /// </summary>
    /// <param name="context">The active rendering context</param>
    /// <exception cref="ArgumentNullException">In case the context is null</exception>
    protected Mesh(IContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        Id = Guid.NewGuid();
    }

    /// <inheritdoc />
    public void Build()
    {
        if (_builded)
        {
            return;
        }

        BufferArray = _context.CreateBufferArray();

        // Vertex Buffer - 0 + 1 for color
        var bufferLayout = new BufferLayout();
        bufferLayout.AddElement(new BufferElement(0, "a_Position", ShaderDataType.Vector4));
        bufferLayout.AddElement(new BufferElement(1, "a_Color", ShaderDataType.Vector4));

        var vbo = _context.CreateBuffer(bufferLayout);
        vbo.SetData(Vertices);

        BufferArray.AddBuffer(vbo, BufferType.Vertex);

        // UV Buffer - 2
        bufferLayout = new BufferLayout();
        bufferLayout.AddElement(new BufferElement(2, "a_TexCoord", ShaderDataType.Vector2));

        var uvBuffer = _context.CreateBuffer(bufferLayout);
        uvBuffer.SetData(UvCoordinates);

        BufferArray.AddBuffer(uvBuffer, BufferType.Uv);

        // Normal Buffer - 3
        bufferLayout = new BufferLayout();
        bufferLayout.AddElement(new BufferElement(3, "a_Normal", ShaderDataType.Vector3));

        var nbo = _context.CreateBuffer(bufferLayout);
        nbo.SetData(Normals);

        BufferArray.AddBuffer(nbo, BufferType.Normal);

        // Index Buffer
        bufferLayout = new BufferLayout();
        bufferLayout.AddElement(new BufferElement(4, "indices", ShaderDataType.Int));

        var ibo = _context.CreateIndexBuffer(bufferLayout);
        ibo.SetData(Indices);

        BufferArray.AddBuffer(ibo, BufferType.Index);

        BufferArray.Build();

        _builded = true;
    }

    public void CalculateNormals()
    {
        if (Vertices == null || Indices == null || Indices.Length % 3 != 0)
        {
            throw new InvalidOperationException("Invalid mesh data.");
        }

        Normals = new Vector3[Vertices.Length];

        for (var i = 0; i < Indices.Length; i += 3)
        {
            var i1 = Indices[i];
            var i2 = Indices[i + 1];
            var i3 = Indices[i + 2];

            var v1 = Vertices[i1].Position.Xyz;
            var v2 = Vertices[i2].Position.Xyz;
            var v3 = Vertices[i3].Position.Xyz;

            var normal = Vector3.Cross(v2 - v1, v3 - v1);

            Normals[i1] += normal;
            Normals[i2] += normal;
            Normals[i3] += normal;
        }

        for (var i = 0; i < Normals.Length; i++)
        {
            Normals[i] = Vector3.Normalize(Normals[i]);
        }
    }

    public bool Equals(IMesh? other) => other is not null && Id.Equals(other.Id);

    private bool Equals(Mesh other) => Id.Equals(other.Id);

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj.GetType() != GetType())
        {
            return false;
        }

        return Equals((Mesh)obj);
    }

    public override int GetHashCode() => Id.GetHashCode();
}
