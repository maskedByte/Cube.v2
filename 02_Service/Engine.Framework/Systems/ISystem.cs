using Engine.Framework.Entities;
using Engine.Rendering.Renderers;

namespace Engine.Framework.Systems;

/// <summary>
///     Represents a system in the ECS (Entity-Component-System) architecture.
/// </summary>
public interface ISystem
{
    /// <summary>
    ///     Updates the system logic.
    /// </summary>
    /// <param name="deltaTime">Time elapsed since the last update.</param>
    void Update(float deltaTime);

    /// <summary>
    ///     Renders the system's visual components.
    /// </summary>
    /// <param name="renderContext">Render context to use for rendering.</param>
    void Render(IRenderer renderContext);

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
