using Engine.Core.Math.Base;
using Engine.Framework.Worlds;

namespace Engine.Framework.Entities;

/// <summary>
/// </summary>
public class Entity : IEntity
{
    private readonly Dictionary<Type, IComponent> _components = new();

    /// <inheritdoc />
    public Guid Id { get; }

    /// <inheritdoc />
    public string Tag { get; set; }

    /// <inheritdoc />
    public bool IsActive { get; set; }

    /// <inheritdoc />
    public World World { get; }

    /// <inheritdoc />
    public IEntity? Parent { get; }

    /// <inheritdoc />
    public List<IEntity> Children { get; }

    /// <inheritdoc />
    public Transform Transform { get; set; }

    /// <inheritdoc />
    public CullingLayer CullingLayer { get; set; }

    /// <summary>
    ///     Creates a new entity.
    /// </summary>
    /// <param name="world">The world that the entity belongs to.</param>
    /// <param name="parent">An optional parent entity that this entity is a child of.</param>
    public Entity(World world, IEntity? parent = null)
    {
        Id = Guid.NewGuid();
        World = world;
        Parent = parent;
        parent?.Children.Add(this);

        Tag = $"Entity-{Id}";
        IsActive = true;
        Transform = new Transform();
        Children = new List<IEntity>();
    }

    /// <inheritdoc />
    public void Dispose()
    {
        // Clear of all components.
        _components.Clear();

        // Dispose of all children.
        foreach (var child in Children)
        {
            child.Dispose();
        }

        Children.Clear();
    }

    /// <inheritdoc />
    public void AddComponent<T>() where T : IComponent
    {
        if (_components.ContainsKey(typeof(T)))
        {
            return;
        }

        var component = Activator.CreateInstance<T>();
        _components.Add(typeof(T), component);
        component.Owner = this;
    }

    /// <inheritdoc />
    public void RemoveComponent<T>() where T : IComponent
    {
        if (!_components.ContainsKey(typeof(T)))
        {
            return;
        }

        _components.Remove(typeof(T));
    }

    /// <inheritdoc />
    public T? GetComponent<T>() where T : IComponent
    {
        if (_components.TryGetValue(typeof(T), out var component))
        {
            return (T)component;
        }

        return default;
    }

    /// <inheritdoc />
    public bool HasComponent<T>() where T : IComponent => _components.ContainsKey(typeof(T));
}
