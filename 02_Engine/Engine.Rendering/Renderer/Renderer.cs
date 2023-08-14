using Engine.Rendering.Commands;

namespace Engine.Rendering.Renderer;

internal class Renderer : IRenderer
{
    private IRenderCommandQueue _renderCommandQueue;
    private Dictionary<RenderCommandType, IRenderCommandHandler> _renderCommandHandlers;

    public void Dispose()
    {
    }

    public void Render()
    {
    }
}
