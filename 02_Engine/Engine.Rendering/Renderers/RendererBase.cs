using Engine.Core.Driver;
using Engine.Rendering.Commands;

namespace Engine.Rendering.Renderers;

public abstract class RendererBase : IRenderer
{
    protected IContext Context { get; }
    protected ICommandQueue CommandQueue { get; }
    protected ICommandHandler CommandHandler { get; }

    protected RendererBase(IContext context, ICommandQueue commandQueue, ICommandHandler commandHandler)
    {
        Context = context ?? throw new ArgumentNullException(nameof(context));
        CommandQueue = commandQueue ?? throw new ArgumentNullException(nameof(commandQueue));
        CommandHandler = commandHandler ?? throw new ArgumentNullException(nameof(commandHandler));
    }

    /// <summary>
    ///     Renders all commands groups in the queue.
    /// </summary>
    public void Render()
    {
        BeginRender();

        while (true)
        {
            if (!CommandQueue.TryDequeue(out var commandGroup) && commandGroup == null)
            {
                break;
            }

            while (commandGroup!.TryGetNext(out var command, out var commandType))
            {
                CommandHandler.HandleCommand(Context, command);
            }
        }

        EndRender();
    }

    public virtual void BeginRender()
    {
    }

    public virtual void EndRender()
    {
    }

    public void Dispose() => CommandQueue.Dispose();
}
