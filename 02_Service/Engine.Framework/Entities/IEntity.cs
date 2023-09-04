using Engine.Framework.Rendering.Worlds;

namespace Engine.Framework.Entities;

/// <summary>
///     Represents an entity in the game world that can have components attached to it.
/// </summary>
public interface IEntity : IDisposable, IComponentOwner
{
    /// <summary>
    ///     Gets a unique identifier for the entity.
    /// </summary>
    Guid Id { get; }

    /// <summary>
    ///     Gets the world that the entity belongs to.
    /// </summary>
    World World { get; }

    /// <summary>
    ///     Gets or sets a tag or label associated with the entity.
    /// </summary>
    string Tag { get; set; }

    /// <summary>
    ///     Gets or sets whether the entity is currently active or not.
    /// </summary>
    bool IsActive { get; set; }

    /// <summary>
    ///     Gets the parent entity that this entity is a child of.
    /// </summary>
    IEntity? Parent { get; set; }

    /// <summary>
    ///     Gets a collection of child entities that belong to this entity.
    /// </summary>
    List<IEntity> Children { get; }

    /// <summary>
    ///     Gets or sets the culling layer of the entity.
    /// </summary>
    CullingLayer CullingLayer { get; set; }
}
