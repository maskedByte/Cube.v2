using System.Collections.Concurrent;

namespace Engine.Framework.Entities;

/// <summary>
///     Represents an entity that can own and manage components.
/// </summary>
public interface IComponentOwner
{
    /// <summary>
    ///     Gets a collection of components owned by the owner.
    /// </summary>
    ConcurrentDictionary<Type, IComponent> Components { get; }

    /// <summary>
    ///     Adds a component of the specified type to the owner.
    /// </summary>
    /// <typeparam name="T">Type of the component.</typeparam>
    T AddComponent<T>() where T : class, IComponent;

    /// <summary>
    ///     Removes a component of the specified type from the owner.
    /// </summary>
    /// <typeparam name="T">Type of the component.</typeparam>
    void RemoveComponent<T>() where T : class, IComponent;

    /// <summary>
    ///     Gets the component of the specified type owned by the owner.
    /// </summary>
    /// <typeparam name="T">Type of the component.</typeparam>
    /// <returns>The component instance if found, otherwise null.</returns>
    T? GetComponent<T>() where T : class, IComponent;

    /// <summary>
    ///     Checks if the owner has a component of the specified type.
    /// </summary>
    /// <typeparam name="T">Type of the component.</typeparam>
    /// <returns>True if the owner has the component, otherwise false.</returns>
    bool HasComponent<T>() where T : class, IComponent;
}
