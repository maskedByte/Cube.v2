using Engine.Core.Rendering.Commands;
using Engine.Core.Rendering.Renderers;

namespace Engine.Rendering.Renderer;

internal class Renderer : IRenderer
{
    private ICommandQueue _commandQueue;
    private Dictionary<CommandType, ICommandHandler> _renderCommandHandlers;

    public void Dispose()
    {
    }

    public void Render()
    {
    }
}
