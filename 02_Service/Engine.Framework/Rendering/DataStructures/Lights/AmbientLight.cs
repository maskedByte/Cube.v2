using Engine.Core.Math.Base;

namespace Engine.Framework.Rendering.DataStructures.Lights;

/// <summary>
///     Ambient light implementation.
/// </summary>
public sealed class AmbientLight : BaseLight
{
    public AmbientLight()
        : base(LightType.Ambient)
    {
        Color = Color.White;
        Intensity = 1f;
    }
}
