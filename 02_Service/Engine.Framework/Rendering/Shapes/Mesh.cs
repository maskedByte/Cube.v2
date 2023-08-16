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
