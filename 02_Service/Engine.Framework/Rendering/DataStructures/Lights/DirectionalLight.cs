namespace Engine.Framework.Rendering.DataStructures.Lights;

/// <summary>
///     Directional light implementation.
/// </summary>
public sealed class DirectionalLight : BaseLight
{
    public DirectionalLight()
        : base(LightType.Directional)
    {
    }
}
