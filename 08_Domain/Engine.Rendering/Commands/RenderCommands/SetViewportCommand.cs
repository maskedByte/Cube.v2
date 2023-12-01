using Engine.Core.Math.Base;

namespace Engine.Rendering.Commands.RenderCommands;

public class SetViewportCommand : CommandBase
{
    public Viewport Viewport { get; }

    public SetViewportCommand(Viewport viewport)
        : base(CommandType.SetViewport)
    {
        Viewport = viewport;
    }
}
