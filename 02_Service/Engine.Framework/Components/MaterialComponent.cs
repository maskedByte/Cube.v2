using Engine.Framework.Entities;
using Engine.Framework.Rendering.DataStructures;

namespace Engine.Framework.Components;

public sealed class MaterialComponent : IComponent
{
    public IEntity Owner { get; set; } = null!;

    public Material Material { get; set; }
}
