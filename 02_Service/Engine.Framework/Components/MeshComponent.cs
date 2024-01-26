using Engine.Core.Driver;
using Engine.Framework.Entities;
using Engine.Rendering.Shapes;

namespace Engine.Framework.Components;

public sealed class MeshComponent : IComponent
{
    public IEntity Owner { get; set; } = null!;

    public PrimitiveType PrimitiveType { get; set; } = PrimitiveType.Triangles;

    public IMesh Mesh { get; set; } = null!;
}
