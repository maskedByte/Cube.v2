namespace Engine.Rendering.Commands.RenderCommands;

public class SetIndexCountCommand : CommandBase
{
    public uint IndexCount { get; }

    public SetIndexCountCommand(uint indexCount)
        : base(CommandType.SetIndexCount)
    {
        IndexCount = indexCount;
    }
}
