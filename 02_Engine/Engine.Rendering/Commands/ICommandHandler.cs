using Engine.Core.Driver;

namespace Engine.Rendering.Commands;

public interface ICommandHandler
{
    /// <summary>
    ///     Handles a rendering command.
    /// </summary>
    /// <param name="context">The rendering context.</param>
    /// <param name="command">The rendering command to handle.</param>
    void HandleCommand(IContext context, ICommand command);

    /// <summary>
    ///     Registers a handler for the specified command type.
    /// </summary>
    /// <param name="type">The type of command to register a handler for.</param>
    /// <param name="handler">The handler to associate with the command type.</param>
    void RegisterHandler(CommandType type, Action<IContext, ICommand> handler);

    /// <summary>
    ///     Unregisters a handler for the specified command type.
    /// </summary>
    /// <param name="type">The type of command to register a handler for.</param>
    void UnregisterHandler(CommandType type);

    /// <summary>
    ///     Adds a rule to the command handler.
    /// </summary>
    /// <param name="rule">A rule to preprocess commands.</param>
    void AddRule(Func<ICommand, bool> rule);
}
