namespace Engine.Framework.Entities;

/// <summary>
///     Represents a component that can be attached to an entity.
/// </summary>
public interface IComponent
{
    /// <summary>
    ///     Gets or sets the owner entity of the component.
    /// </summary>
    IEntity? Owner { get; set; }
}
