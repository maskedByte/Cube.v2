using Engine.Framework.Entities;
using Engine.Rendering.Commands;

namespace Engine.Framework.Systems;

/// <summary>
///     Represents a system in the ECS (Entity-Component-System) architecture.
/// </summary>
public interface ISystem
{
    /// <summary>
    /// Processes the component.
    /// </summary>
    /// <param name="component">The component to update.</param>
    /// <param name="commandQueue">The command queue to add commands to.</param>
    /// <param name="deltaTime">Time elapsed since the last update.</param>
    void Handle(IComponent component, ICommandQueue commandQueue, float deltaTime);

    /// <summary>
    ///     Determines if the system is responsible for handling a specific component type.
    /// </summary>
    /// <typeparam name="T">Type of the component.</typeparam>
    /// <returns>True if the system handles the component type, otherwise false.</returns>
    bool HandlesComponent<T>() where T : IComponent;

    /// <summary>
    ///     Cleans up and disposes the system.
    /// </summary>
    void Dispose();
}
