using Engine.Framework.Entities;
using Engine.Rendering.Shapes;

namespace Engine.Framework.Components;

public class MeshComponent : IComponent
{
    public IEntity Owner { get; set; } = null!;

    public IMesh Mesh { get; set; } = null!;
}
