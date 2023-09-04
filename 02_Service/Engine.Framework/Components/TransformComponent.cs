using Engine.Core.Math.Base;
using Engine.Framework.Entities;

namespace Engine.Framework.Components;

public class TransformComponent : IComponent
{
    public IEntity Owner { get; set; } = null!;
    public Transform Transform { get; set; } = new();
}
