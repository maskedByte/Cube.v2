using Engine.Core.Driver;

namespace Engine.Rendering.Commands;

/// <summary>
///     Command handler for rendering commands.
/// </summary>
public abstract class CommandHandlerBase : ICommandHandler
{
    private readonly Dictionary<CommandType, Action<IContext, ICommand>> _commandHandlers;
    private readonly List<Func<ICommand, bool>> _commandRules;

    /// <summary>
    ///     Base implementation of a command handler.
    /// </summary>
    protected CommandHandlerBase()
    {
        _commandHandlers = new Dictionary<CommandType, Action<IContext, ICommand>>();
        _commandRules = new List<Func<ICommand, bool>>();
    }

    /// <inheritdoc />
    public void Handle(IContext context, ICommand command)
    {
        if (_commandHandlers.TryGetValue(command.Type, out var handler))
        {
            if (!_commandRules.Any() || _commandRules.TrueForAll(func => func(command)))
            {
                handler(context, command);
            }
        }
        else
        {
            throw new InvalidOperationException($"Handler for CommandType {command.Type} not registered.");
        }
    }

    /// <inheritdoc />
    public void AddRule(Func<ICommand, bool> rule) => _commandRules.Add(rule);

    /// <inheritdoc />
    public void RegisterCommandTypeHandler(CommandType type, Action<IContext, ICommand> handler) => _commandHandlers[type] = handler;

    /// <inheritdoc />
    public void UnregisterCommandTypeHandler(CommandType type) => _commandHandlers.Remove(type);

    public void Dispose()
    {
        _commandHandlers.Clear();
        _commandRules.Clear();
    }
}
