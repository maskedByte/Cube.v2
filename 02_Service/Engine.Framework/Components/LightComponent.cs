using Engine.Core.Math.Base;
using Engine.Framework.Entities;
using Engine.Framework.Rendering.DataStructures;

namespace Engine.Framework.Components;

public class LightComponent : IComponent
{
    public IEntity Owner { get; set; } = null!;
    public LightType Type { get; set; } = LightType.Point;
    public Color Color { get; set; } = Color.White;
    public float Intensity { get; set; } = 1f;
    public float Range { get; set; } = 5f;
}
