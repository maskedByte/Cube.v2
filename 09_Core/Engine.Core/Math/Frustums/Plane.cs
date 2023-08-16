using System.Runtime.InteropServices;
using Engine.Core.Math.Vectors;

namespace Engine.Core.Math.Frustums;

/// <summary>
///     Represents a plane in 3D space
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly struct FrustumPlane
{
    public readonly Vector3 Normal;
    public readonly float Distance;

    public FrustumPlane(Vector3 normal, float distance)
    {
        Normal = normal;
        Distance = distance;
    }
}
