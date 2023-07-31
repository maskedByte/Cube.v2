namespace Engine.Math.Frustum;

/// <summary>
/// Represents a frustum in 3D space
/// </summary>
public class Frustum
{
    public FrustumPlane Top { get; }
    public FrustumPlane Bottom { get; }

    public FrustumPlane Left { get; }
    public FrustumPlane Right { get; }

    public FrustumPlane Near { get; }
    public FrustumPlane Far { get; }
}
