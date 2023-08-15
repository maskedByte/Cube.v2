using Engine.Core.Driver;
using Engine.Rendering.Commands;

namespace Engine.Rendering.Renderers;

public class DefaultRenderer : RendererBase
{
    public DefaultRenderer(IContext context, ICommandQueue commandQueue, ICommandHandler commandHandler)
        : base(context, commandQueue, commandHandler)
    {
    }

    public override void BeginRender() => Context.Wireframe = false;

    public override void EndRender()
    {
    }
}
