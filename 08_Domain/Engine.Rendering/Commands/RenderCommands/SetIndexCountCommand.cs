namespace Engine.Rendering.Commands.RenderCommands;

public class SetIndexCountCommand : CommandBase
{
    public uint IndexCount { get; set; }

    public SetIndexCountCommand(uint indexCount)
        : base(CommandType.SetIndexCount)
    {
        IndexCount = indexCount;
    }
}
