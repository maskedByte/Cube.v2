namespace Engine.Rendering.Commands.RenderCommands;

/// <summary>
///     Render an element has high priority to ensure that it always handled last.
/// </summary>
public sealed class DrawElementsCommand : CommandBase
{
    public DrawElementsCommand()
        : base(CommandType.RenderElement)
    {
        Priority = 999999999;
    }
}
