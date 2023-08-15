using Engine.Core.Rendering.Commands;

namespace Engine.Rendering.Commands.RenderCommands;

public sealed class RenderElementCommand : CommandBase
{
    public RenderElementCommand()
        : base(CommandType.RenderElement)
    {
    }
}
