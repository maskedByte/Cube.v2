using Engine.Framework.Entities;
using Engine.Framework.Rendering.DataStructures.Lights;

namespace Engine.Framework.Components;

public abstract class LightComponentBase<TLight> : IComponent
{
    public TLight Light { get; }

    public IEntity Owner { get; set; } = null!;

    protected LightComponentBase(TLight light)
    {
        Light = light;
    }
}

public sealed class AmbientLightComponent : LightComponentBase<AmbientLight>
{
    public AmbientLightComponent()
        : base(new AmbientLight())
    {
    }
}

public sealed class DirectionalLightComponent : LightComponentBase<DirectionalLight>
{
    public DirectionalLightComponent()
        : base(new DirectionalLight())
    {
    }
}

public sealed class PointLightComponent : LightComponentBase<PointLight>
{
    public PointLightComponent()
        : base(new PointLight())
    {
    }
}

public sealed class SpotLightComponent : LightComponentBase<SpotLight>
{
    public SpotLightComponent()
        : base(new SpotLight())
    {
    }
}
