namespace Engine.Rendering.Commands.RenderCommands;

/// <summary>
///     Render an element has high priority to ensure that it always handled last.
/// </summary>
public sealed class RenderElementCommand : CommandBase
{
    public RenderElementCommand()
        : base(CommandType.RenderElement)
    {
        Priority = 999999999;
    }
}
