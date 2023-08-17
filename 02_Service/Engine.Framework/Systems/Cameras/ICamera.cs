using Engine.Core.Events;
using Engine.Core.Math.Base;
using Engine.Core.Math.Matrices;
using Engine.Core.Math.Vectors;

namespace Engine.Framework.Systems.Cameras;

/// <summary>
///     Interface for camera classes
/// </summary>
public interface ICamera : IEventSubscriber
{
    /// <summary>
    ///     Get the view matrix of the camera
    /// </summary>
    Matrix4 ViewMatrix { get; }

    /// <summary>
    ///     Get or set the camera transform
    /// </summary>
    Transform Transform { get; set; }

    /// <summary>
    ///     Set or get camera Up vector
    /// </summary>
    Vector3 Up { get; set; }

    /// <summary>
    ///     Set or get camera Right vector
    /// </summary>
    Vector3 Right { get; set; }

    /// <summary>
    ///     Set or get camera Forward vector
    /// </summary>
    Vector3 Forward { get; set; }

    /// <summary>
    ///     Get the actual near clip plane, for 3D camera only
    /// </summary>
    float NearClip { get; }

    /// <summary>
    ///     Get the actual far clip plane, for 3D camera only
    /// </summary>
    float FarClip { get; }

    /// <summary>
    ///     Set the near and far clip planes
    /// </summary>
    /// <param name="near"></param>
    /// <param name="far"></param>
    void SetClipPlane(float near, float far);

    /// <summary>
    ///     Returns a projection matrix for the set <see cref="ProjectionMode" />
    /// </summary>
    /// <param name="projectionMode"></param>
    /// <returns></returns>
    Matrix4 GetProjection(ProjectionMode projectionMode);
}
