using Engine.Core.Math.Base;
using Engine.Core.Math.Matrices;
using Engine.Core.Math.Vectors;
using Engine.Framework.Entities;
using Engine.Framework.Rendering.Cameras;

namespace Engine.Framework.Components;

/// <summary>
///     The camera component.
/// </summary>
public sealed class CameraComponent : IComponent
{
    private (float nearClip, float farClip) _clipPlane;
    private IEntity _owner;

    internal Camera? Camera;

    /// <summary>
    ///     Gets or sets the projection mode.
    /// </summary>
    public ProjectionMode ProjectionMode { get; set; }

    /// <summary>
    ///     Gets or sets the near clip plane.
    /// </summary>
    public float NearClip
    {
        get => _clipPlane.nearClip;
        set
        {
            _clipPlane.nearClip = value;
            Camera!.SetClipPlane(_clipPlane.nearClip, _clipPlane.farClip);
        }
    }

    /// <summary>
    ///     Return the view matrix
    /// </summary>
    public Matrix4 ViewMatrix => Camera?.ViewMatrix ?? Matrix4.Identity;

    /// <summary>
    ///     Get the camera forward vector
    /// </summary>
    public Vector3 Forward => Camera?.Forward ?? Vector3.Forward;

    /// <summary>
    ///     Get the camera right vector
    /// </summary>
    public Vector3 Right => Camera?.Right ?? Vector3.Right;

    /// <summary>
    ///     Get the camera right vector
    /// </summary>
    public Vector3 Up => Camera?.Up ?? Vector3.Up;

    /// <summary>
    ///     Gets or sets the far clip plane.
    /// </summary>
    public float FarClip
    {
        get => _clipPlane.farClip;
        set
        {
            _clipPlane.farClip = value;
            Camera!.SetClipPlane(_clipPlane.nearClip, _clipPlane.farClip);
        }
    }

    /// <summary>
    ///     Gets or sets the clear color.
    /// </summary>
    public Color ClearColor
    {
        get => Camera!.ClearColor;
        set => Camera!.ClearColor = value;
    }

    /// <summary>
    ///     Gets or sets the field of view.
    /// </summary>
    public float FieldOfView
    {
        get => Camera!.FieldOfView;
        set => Camera!.FieldOfView = value;
    }

    public IEntity Owner
    {
        get => _owner;
        set
        {
            _owner = value;
            Camera ??= new Camera(_owner.World.Core.ActiveDriver);
            Camera.Transform.Parent = _owner.GetComponent<TransformComponent>()!.Transform;
        }
    }

    /// <summary>
    ///     Default parameterless constructor.
    /// </summary>
    public CameraComponent()
    {
        _owner = null!;
        Camera = null!;
        ProjectionMode = ProjectionMode.Orthographic;
    }
}
