using Engine.Core.Driver;

namespace Engine.Rendering.Commands.ProcessCommands;

public class ProcessCommand : CommandBase
{
    public Func<IContext, ICommand?> CommandFunc { get; }

    public ProcessCommand(Func<IContext, ICommand?> commandFunc)
        : base(CommandType.ProcessCommand)
    {
        CommandFunc = commandFunc;
    }
}
