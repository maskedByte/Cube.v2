namespace Engine.Framework.Rendering.DataStructures.Lights;

/// <summary>
///     Point light implementation.
/// </summary>
public sealed class PointLight : BaseLight
{
    /// <summary>
    ///     The radius of the light.
    /// </summary>
    public float Radius { get; set; }

    public PointLight()
        : base(LightType.Point)
    {
    }
}
