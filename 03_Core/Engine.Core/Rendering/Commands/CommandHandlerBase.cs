using Engine.Core.Driver;

namespace Engine.Core.Rendering.Commands;

/// <summary>
///     Command handler for rendering commands.
/// </summary>
public abstract class CommandHandlerBase : ICommandHandler
{
    private readonly Dictionary<CommandType, Action<IContext, ICommand>> _commandHandlers;

    /// <summary>
    ///     Base implementation of a command handler.
    /// </summary>
    protected CommandHandlerBase()
    {
        _commandHandlers = new Dictionary<CommandType, Action<IContext, ICommand>>();
    }

    /// <inheritdoc />
    public void HandleCommand(IContext context, ICommand command)
    {
        if (_commandHandlers.TryGetValue(command.Type, out var handler))
        {
            handler(context, command);
        }
        else
        {
            throw new InvalidOperationException($"Handler for CommandType {command.Type} not registered.");
        }
    }

    /// <inheritdoc />
    public void RegisterHandler(CommandType type, Action<IContext, ICommand> handler) => _commandHandlers[type] = handler;

    /// <inheritdoc />
    public void UnregisterHandler(CommandType type) => _commandHandlers.Remove(type);
}
