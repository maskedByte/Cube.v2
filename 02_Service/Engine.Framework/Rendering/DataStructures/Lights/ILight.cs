using Engine.Core.Math.Base;

namespace Engine.Framework.Rendering.DataStructures.Lights;

/// <summary>
///     Basic interface for a light which is used as a system in a component.
/// </summary>
public interface ILight
{
    /// <summary>
    ///     The light color.
    /// </summary>
    Color Color { get; set; }

    /// <summary>
    ///     The light intensity.
    /// </summary>
    float Intensity { get; set; }

    /// <summary>
    ///     The light type.
    /// </summary>
    LightType Type { get; }
}
