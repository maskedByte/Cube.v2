using Engine.Core.Events;
using Engine.Core.Math.Base;
using Engine.Core.Math.Matrices;
using Engine.OpenGL.Driver.Events;

namespace Engine.Framework.Rendering.DataStructures;

/// <summary>
///     Interface for camera classes
/// </summary>
public interface ICamera : IEventListener<ViewportChangedEvent>
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
    ///     Get the actual near clip plane, for 3D camera only
    /// </summary>
    float NearClip { get; }

    /// <summary>
    ///     Get the actual far clip plane, for 3D camera only
    /// </summary>
    float FarClip { get; }

    /// <summary>
    ///     Get the perspective projection matrix
    /// </summary>
    Matrix4 PerspectiveMatrix { get; }

    /// <summary>
    ///     Get the orthographic projection matrix
    /// </summary>
    Matrix4 OrthographicMatrix { get; }

    /// <summary>
    ///     Get or set the clear color
    /// </summary>
    Color ClearColor { get; set; }

    /// <summary>
    ///     Set the near and far clip planes
    /// </summary>
    /// <param name="near"></param>
    /// <param name="far"></param>
    void SetClipPlane(float near, float far);
}
