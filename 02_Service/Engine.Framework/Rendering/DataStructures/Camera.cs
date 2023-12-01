using Engine.Core.Driver;
using Engine.Core.Events;
using Engine.Core.Logging;
using Engine.Core.Math;
using Engine.Core.Math.Base;
using Engine.Core.Math.Matrices;
using Engine.OpenGL.Driver.Events;

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

namespace Engine.Framework.Rendering.DataStructures;

public sealed class Camera : ICamera
{
    private readonly IDriver _driver;
    private Color _clearColor;
    private Matrix4 _orthographicProjectionMatrix;
    private Matrix4 _perspectiveProjectionMatrix;

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
    public Matrix4 PerspectiveMatrix
    {
        get
        {
            CalculateProjections(ProjectionMode.Perspective);
            return _perspectiveProjectionMatrix;
        }
    }

    /// <inheritdoc />
    public Matrix4 OrthographicMatrix
    {
        get
        {
            CalculateProjections(ProjectionMode.Orthographic);
            return _orthographicProjectionMatrix;
        }
    }

    /// <inheritdoc />
    public Color ClearColor
    {
        get => _clearColor;
        set
        {
            _clearColor = value;
            _driver.GetContext()?.SetClearColor(_clearColor);
        }
    }

    public float FieldOfView { get; set; }

    /// <inheritdoc />
    public Transform Transform { get; set; }

    /// <inheritdoc />
    public float NearClip { get; private set; }

    /// <inheritdoc />
    public float FarClip { get; private set; }

    /// <summary>
    ///     Current viewport of the camera.
    /// </summary>
    internal Viewport CurrentViewport { get; private set; }

    internal bool ViewportHasChanged { get; private set; }

    /// <summary>
    ///     Initialize a new Camera
    /// </summary>
    public Camera(IDriver driver)
    {
        ArgumentNullException.ThrowIfNull(driver);
        _driver = driver;

        if (_driver.GetContext() == null)
        {
            Log.LogMessageAsync("Context was not found, cannot create camera!", LogLevel.Critical, this);
            throw new Exception();
        }

        if (_driver.GetWindow() == null)
        {
            Log.LogMessageAsync("No window found, cannot create camera!", LogLevel.Critical, this);
            throw new Exception();
        }

        EventBus.Subscribe(this);
        CurrentViewport = _driver.GetWindow()!.Viewport;

        _recalculateProjection = true;
        _orthographicProjectionMatrix = Matrix4.Identity;
        _perspectiveProjectionMatrix = Matrix4.Identity;
        NearClip = 0.001f;
        FarClip = 1000f;
        _clearColor = Color.Black;
        ClearColor = Color.Black;
        FieldOfView = 45f;

        Transform = new Transform
        {
            AutoRecalculate = false
        };
    }

    /// <inheritdoc />
    public void SetClipPlane(float near, float far)
    {
        NearClip = near;
        FarClip = far;
    }

    private void CalculateProjections(ProjectionMode projectionMode)
    {
        if (!_recalculateProjection)
        {
            return;
        }

        if (projectionMode == ProjectionMode.Orthographic)
        {
            _orthographicProjectionMatrix = Matrix4.CreateOrthographic(
                0f,
                CurrentViewport.Width,
                CurrentViewport.Height,
                0f,
                0.1f,
                int.MaxValue
            );

            _orthographicProjectionMatrix.M22 *= -1f;
        }

        if (projectionMode == ProjectionMode.Perspective)
        {
            _perspectiveProjectionMatrix = Matrix4.CreatePerspectiveFieldOfView(
                Mathf.DegreesToRadians(FieldOfView),
                CurrentViewport.Width / CurrentViewport.Height,
                NearClip,
                FarClip
            );
        }

        _recalculateProjection = false;
    }

    /// <summary>
    ///     Calculates the view matrix for the camera based on the current position and rotation by calculating the forward and
    ///     up vectors.
    /// </summary>
    private void CalculateViewMatrix()
    {
        _ = Transform.Transformation;
        var position = Transform.Position;
        _viewMatrix = Matrix4.LookAt(position, position + Transform.Forward, Transform.Up);
    }

    public void ReceiveEvent(ViewportChangedEvent data)
    {
        CurrentViewport = data.Data;
        ViewportHasChanged = true;
        _recalculateProjection = true;
    }
}
