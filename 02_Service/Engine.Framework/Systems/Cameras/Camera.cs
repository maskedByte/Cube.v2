using Engine.Core.Driver.Window;
using Engine.Core.Events;
using Engine.Core.Math;
using Engine.Core.Math.Base;
using Engine.Core.Math.Matrices;
using Engine.Core.Math.Vectors;

namespace Engine.Framework.Systems.Cameras;

public class Camera : ICamera
{
    private float _aspectRatio;
    private Viewport _currentViewport;
    private Matrix4 _orthoProjMat;
    private Matrix4 _perspectiveProjMat;

    private bool _recalculateProjection;
    private Matrix4 _viewMatrix;

    /// <inheritdoc />
    public Matrix4 ViewMatrix
    {
        get
        {
            CalculateViewMatrix();
            return _viewMatrix;
        }
    }

    /// <inheritdoc />
    public Transform Transform { get; set; }

    /// <inheritdoc />
    public Vector3 Up { get; set; }

    /// <inheritdoc />
    public Vector3 Right { get; set; }

    /// <inheritdoc />
    public Vector3 Forward { get; set; }

    /// <inheritdoc />
    public float NearClip { get; private set; }

    /// <inheritdoc />
    public float FarClip { get; private set; }

    /// <summary>
    ///     Initialize a new Camera
    /// </summary>
    public Camera(IWindow window)
    {
        EventBus.Subscribe("ViewportChangedEvent", this);
        _currentViewport = window.Viewport;

        _recalculateProjection = true;
        _aspectRatio = 1f;
        _orthoProjMat = Matrix4.Identity;
        _perspectiveProjMat = Matrix4.Identity;
        NearClip = 0.001f;
        FarClip = 1000f;

        Forward = Vector3.UnitZ;
        Right = Vector3.UnitX;
        Up = Vector3.UnitY;

        Transform = new Transform();
        Transform.AutoRecalculate = false;

        _viewMatrix = Matrix4.LookAt(
            Transform.Position,
            Transform.Position + Forward,
            Up
        );

        CalculateProjections();
    }

    /// <inheritdoc />
    public void SetClipPlane(float near, float far)
    {
        NearClip = near;
        FarClip = far;
    }

    /// <inheritdoc />
    public Matrix4 GetProjection(ProjectionMode projectionMode) =>
        projectionMode switch
        {
            ProjectionMode.Orthographic => _orthoProjMat,
            ProjectionMode.Perspective  => _perspectiveProjMat,
            _                           => throw new ArgumentOutOfRangeException(nameof(projectionMode), projectionMode, null)
        };

    /// <inheritdoc />
    public void ReceiveEvent<T>(T data)
    {
        if (data == null || data.GetType() != typeof(Viewport))
        {
            return;
        }

        _currentViewport = data is Viewport viewport
            ? viewport
            : default;
        _recalculateProjection = true;
    }

    private void CalculateProjections()
    {
        if (!_recalculateProjection)
        {
            return;
        }

        _aspectRatio = _currentViewport.Width / _currentViewport.Height;

        // Rotate the projection matrix to invert the Y axis
        var reflectionMatrix = Matrix4.Identity;
        reflectionMatrix.M22 = -1f;

        _orthoProjMat = reflectionMatrix
                        * Matrix4.CreateOrthographic(
                            0f,
                            _currentViewport.Width,
                            _currentViewport.Height,
                            0f,
                            -int.MaxValue,
                            int.MaxValue
                        );

        _perspectiveProjMat = Matrix4.CreatePerspectiveFieldOfView(
            Mathf.DegreesToRadians(50.0f),
            _aspectRatio,
            NearClip,
            FarClip
        );
        _perspectiveProjMat.M11 *= -1;

        _recalculateProjection = false;
    }

    private void CalculateViewMatrix() =>
        _viewMatrix = Matrix4.LookAt(
            Transform.Position,
            Transform.Position + Forward,
            Up
        );
}
