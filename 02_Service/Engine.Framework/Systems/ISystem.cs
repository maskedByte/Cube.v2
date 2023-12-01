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
    /// <param name="stage">The stage of the system.</param>
    /// <param name="component">The component to update.</param>
    /// <param name="commandQueue">The command queue to add commands to.</param>
    /// <param name="deltaTime">Time elapsed since the last update.</param>
    void Handle(SystemStage stage, IComponent component, ICommandQueue commandQueue, float deltaTime);

    /// <summary>
    ///     Gets the type of component this system can handle.
    /// </summary>
    Type AssignTo();

    /// <summary>
    ///     Cleans up and disposes the system.
    /// </summary>
    void Dispose();
}
