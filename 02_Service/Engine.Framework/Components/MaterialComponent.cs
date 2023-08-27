using Engine.Framework.Entities;
using Engine.Framework.Rendering.Materials;

namespace Engine.Framework.Components;

public class MaterialComponent : IComponent
{
    public IEntity Owner { get; set; }

    public Material Material { get; set; }
}
