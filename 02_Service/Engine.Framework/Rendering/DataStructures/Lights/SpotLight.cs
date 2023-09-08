namespace Engine.Framework.Rendering.DataStructures.Lights;

/// <summary>
///     Spot light implementation.
/// </summary>
public sealed class SpotLight : BaseLight
{
    /// <summary>
    ///     The outer radius of the light.
    /// </summary>
    public float Radius { get; set; }

    /// <summary>
    ///     The lights outer radius falloff.
    /// </summary>
    public float Falloff { get; set; }

    public SpotLight()
        : base(LightType.Spot)
    {
    }
}
