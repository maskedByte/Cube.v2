namespace Engine.Framework.Rendering.DataStructures.Lights;

/// <summary>
///     Ambient light implementation.
/// </summary>
public sealed class AmbientLight : BaseLight
{
    public AmbientLight()
        : base(LightType.Ambient)
    {
    }
}
