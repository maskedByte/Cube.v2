using Engine.Core.Math.Base;
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
    ///     Set or gets the near clip plane.
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
    ///     Set or gets the far clip plane.
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
    ///     Set or gets the clear color.
    /// </summary>
    public Color ClearColor
    {
        get => Camera!.ClearColor;
        set => Camera!.ClearColor = value;
    }

    public IEntity Owner
    {
        get => _owner;
        set
        {
            _owner = value;
            Camera ??= new Camera(_owner.World.Core.ActiveDriver);
            Camera.Transform.Parent = _owner.Transform;
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
