using Engine.Framework.Entities;
using Engine.Rendering.Shapes;

namespace Engine.Framework.Components;

public class MeshComponent : IComponent
{
    public IEntity? Owner { get; set; }

    public IMesh? Mesh { get; set; }
}
