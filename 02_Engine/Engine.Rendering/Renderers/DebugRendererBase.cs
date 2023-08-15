using Engine.Core.Driver;
using Engine.Rendering.Commands;

namespace Engine.Rendering.Renderers;

public class DebugRendererBase : RendererBase
{
    private bool _currentWireframeState;

    public DebugRendererBase(IContext context, ICommandQueue commandQueue, ICommandHandler commandHandler)
        : base(context, commandQueue, commandHandler)
    {
    }

    public override void BeginRender()
    {
        _currentWireframeState = Context.Wireframe;
        Context.Wireframe = true;
    }

    public override void EndRender() => Context.Wireframe = _currentWireframeState;
}
