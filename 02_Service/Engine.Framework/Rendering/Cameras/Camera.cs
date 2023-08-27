using Engine.Core.Driver;
using Engine.Core.Events;
using Engine.Core.Logging;
using Engine.Core.Math;
using Engine.Core.Math.Base;
using Engine.Core.Math.Matrices;
using Engine.Core.Math.Vectors;

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

namespace Engine.Framework.Rendering.Cameras;

public class Camera : ICamera
{
    private readonly IDriver _driver;
    private Color _clearColor;
    private Viewport _currentViewport;
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
            CalculateProjections();
            return _perspectiveProjectionMatrix;
        }
    }

    /// <inheritdoc />
    public Matrix4 OrthographicMatrix
    {
        get
        {
            CalculateProjections();
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

    /// <inheritdoc />
    public Transform Transform { get; set; }

    /// <inheritdoc />
    public float NearClip { get; private set; }

    /// <inheritdoc />
    public float FarClip { get; private set; }

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

        EventBus.Subscribe("ViewportChangedEvent", this);
        _currentViewport = _driver.GetWindow()!.Viewport;

        _recalculateProjection = true;
        _orthographicProjectionMatrix = Matrix4.Identity;
        _perspectiveProjectionMatrix = Matrix4.Identity;
        NearClip = 0.001f;
        FarClip = 1000f;
        _clearColor = Color.Black;
        ClearColor = Color.Black;

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

    /// <inheritdoc />
    public Matrix4 GetProjection(ProjectionMode projectionMode)
    {
        CalculateProjections();

        return projectionMode switch
        {
            ProjectionMode.Orthographic => OrthographicMatrix,
            ProjectionMode.Perspective  => PerspectiveMatrix,
            _                           => throw new ArgumentOutOfRangeException(nameof(projectionMode), projectionMode, null)
        };
    }

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

        // Rotate the projection matrix to invert the Y axis
        _orthographicProjectionMatrix = Matrix4.CreateOrthographic(
            0f,
            _currentViewport.Width,
            _currentViewport.Height,
            0f,
            -int.MaxValue,
            int.MaxValue
        );
        _orthographicProjectionMatrix.M22 *= -1f;

        // ReSharper disable once PossibleLossOfFraction
        _perspectiveProjectionMatrix = Matrix4.CreatePerspectiveFieldOfView(
            Mathf.DegreesToRadians(50.0f),
            _currentViewport.Width / _currentViewport.Height,
            NearClip,
            FarClip
        );

        //_perspectiveProjectionMatrix.M11 *= -1;

        _recalculateProjection = false;
    }

    private void CalculateViewMatrix()
    {
        // Ensure the Transform matrix is up to date
        _ = Transform.Transformation;

        var position = Transform.Position;
        var rotation = Transform.Rotation;

        var forward = Vector3.Transform(-Vector3.Forward, rotation);
        var up = Vector3.Transform(Vector3.Up, rotation);

        _viewMatrix = Matrix4.LookAt(position, position + forward, up);
    }
}
