using Engine.Core.Driver;
using Engine.Core.Rendering.Commands;
using Engine.Core.Rendering.Renderers;

namespace Engine.Rendering.Renderer;

public class Renderer : IRenderer
{
    private readonly IContext _context;
    private readonly ICommandQueue _commandQueue;
    private readonly ICommandHandler _commandHandler;

    public Renderer(IContext context, ICommandQueue commandQueue, ICommandHandler commandHandler)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _commandQueue = commandQueue ?? throw new ArgumentNullException(nameof(commandQueue));
        _commandHandler = commandHandler ?? throw new ArgumentNullException(nameof(commandHandler));
    }

    public void Render()
    {
        while (true)
        {
            if (!_commandQueue.TryDequeue(out var commandGroup) && commandGroup == null)
            {
                break;
            }

            while (commandGroup!.TryGetNext(out var command, out var commandType))
            {
                _commandHandler.HandleCommand(_context, command);
            }
        }
    }

    public void Dispose() => _commandQueue.Dispose();
}
