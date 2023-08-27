using Engine.Framework.Entities;
using Engine.Framework.Rendering.Cameras;

namespace Engine.Framework.Components;

/// <summary>
///     The camera component.
/// </summary>
public sealed class CameraComponent : IComponent
{
    private IEntity _owner;
    private Camera? _camera;

    public IEntity Owner
    {
        get => _owner;
        set
        {
            _owner = value;
            _camera ??= new Camera(_owner.World.Core.ActiveDriver);
        }
    }

    /// <summary>
    ///     Default parameterless constructor.
    /// </summary>
    public CameraComponent()
    {
        _owner = null!;
        _camera = null!;
    }
}
