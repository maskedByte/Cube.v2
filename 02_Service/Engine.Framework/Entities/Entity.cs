﻿using System.Collections.Concurrent;
using Engine.Framework.Components;
using Engine.Framework.Rendering.Worlds;

namespace Engine.Framework.Entities;

/// <summary>
/// </summary>
public class Entity : IEntity
{
    private IEntity? _parent;

    /// <inheritdoc />
    public ConcurrentDictionary<Type, IComponent> Components { get; } = new();

    /// <inheritdoc />
    public Guid Id { get; }

    /// <inheritdoc />
    public string Tag { get; set; }

    /// <inheritdoc />
    public bool IsActive { get; set; }

    /// <inheritdoc />
    public World World { get; }

    /// <inheritdoc />
    public IEntity? Parent
    {
        get => _parent;
        set
        {
            if (value == this)
            {
                throw new InvalidOperationException("Cannot set parent to self.");
            }

            if (_parent == value)
            {
                return;
            }

            _parent?.Children.Remove(this);
            value?.Children.Add(this);
            _parent = value;
            var transform = GetComponent<TransformComponent>();
            transform!.Transform.Parent = _parent?.GetComponent<TransformComponent>()!.Transform.Parent ?? World.Transform;
        }
    }

    /// <inheritdoc />
    public List<IEntity> Children { get; }

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
        AddComponent<TransformComponent>();
        Children = new List<IEntity>();

        World = world;
        Tag = $"Entity-{Id}";
        IsActive = true;

        Parent = parent;
        Parent?.Children.Add(this);

        World.AddEntity(this);
    }

    /// <inheritdoc />
    public void Dispose()
    {
        // Clear of all components.
        Components.Clear();

        // Dispose of all children.
        foreach (var child in Children)
        {
            child.Dispose();
        }

        Children.Clear();
    }

    /// <inheritdoc />
    public T AddComponent<T>() where T : class, IComponent
    {
        if (Components.TryGetValue(typeof(T), out var value))
        {
            return (T)value;
        }

        var component = Activator.CreateInstance<T>();

        // Error handling!

        Components.TryAdd(typeof(T), component);
        component.Owner = this;
        return component;
    }

    /// <inheritdoc />
    public void RemoveComponent<T>() where T : class, IComponent
    {
        if (!Components.ContainsKey(typeof(T)))
        {
            return;
        }

        Components.TryRemove(typeof(T), out _);
    }

    /// <inheritdoc />
    public T? GetComponent<T>() where T : class, IComponent
    {
        if (Components.TryGetValue(typeof(T), out var component))
        {
            return (T)component;
        }

        return default;
    }

    /// <inheritdoc />
    public bool HasComponent<T>() where T : class, IComponent => Components.ContainsKey(typeof(T));
}
