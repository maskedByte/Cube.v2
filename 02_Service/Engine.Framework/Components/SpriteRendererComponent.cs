using Engine.Framework.Entities;
using Engine.Rendering.Shapes;

namespace Engine.Framework.Components;

public sealed class SpriteRendererComponent : IComponent
{
    public IEntity Owner { get; set; } = null!;
    public IMesh Mesh { get; set; } = null!;
}
