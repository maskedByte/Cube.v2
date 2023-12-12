using System.Collections.Concurrent;
using Engine.Core.Driver;
using Engine.Core.Logging;

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

namespace Engine.Rendering.Commands;

/// <summary>
///     Command handler for rendering commands.
/// </summary>
public abstract class CommandHandlerBase : ICommandHandler
{
    private readonly ConcurrentDictionary<CommandType, Action<IContext, ICommand>> _commandHandlers;
    private readonly ConcurrentBag<Func<ICommand, bool>> _commandRules;

    /// <summary>
    ///     Base implementation of a command handler.
    /// </summary>
    protected CommandHandlerBase()
    {
        _commandHandlers = new ConcurrentDictionary<CommandType, Action<IContext, ICommand>>();
        _commandRules = new ConcurrentBag<Func<ICommand, bool>>();
    }

    /// <inheritdoc />
    public void Handle(IContext context, ICommand command)
    {
        if (_commandHandlers.TryGetValue(command.Type, out var handler))
        {
            if (!_commandRules.Any() || _commandRules.All(func => func(command)))
            {
                handler(context, command);
            }
        }
        else
        {
            Log.LogMessageAsync($"Handler for CommandType {command.Type} not registered.", LogLevel.Error, this);
        }
    }

    /// <inheritdoc />
    public void AddRule(Func<ICommand, bool> rule) => _commandRules.Add(rule);

    /// <inheritdoc />
    public void RegisterCommandTypeHandler(CommandType type, Action<IContext, ICommand> handler)
    {
        if (!_commandHandlers.TryAdd(type, handler))
        {
            Log.LogMessageAsync($"Handler for CommandType {type} already registered.", LogLevel.Debug, this);
        }
    }

    /// <inheritdoc />
    public void UnregisterCommandTypeHandler(CommandType type)
    {
        if (!_commandHandlers.TryRemove(type, out _))
        {
            Log.LogMessageAsync($"Handler for CommandType {type} not found.", LogLevel.Debug, this);
        }
    }

    public void Dispose()
    {
        _commandHandlers.Clear();
        _commandRules.Clear();
    }
}
