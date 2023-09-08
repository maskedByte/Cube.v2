using Engine.Core.Math.Base;

namespace Engine.Framework.Rendering.DataStructures.Lights;

/// <summary>
///     Basic light to specify the correct type.
/// </summary>
public abstract class BaseLight : ILight
{
    /// <inheritdoc />
    public Color Color { get; set; }

    /// <inheritdoc />
    public float Intensity { get; set; }

    /// <inheritdoc />
    public LightType Type { get; set; }

    protected BaseLight(LightType type)
    {
        Type = type;
        Color = Color.White;
        Intensity = 1f;
    }
}
