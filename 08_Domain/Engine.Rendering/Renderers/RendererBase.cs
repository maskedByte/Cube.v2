using Engine.Core.Driver;
using Engine.Rendering.Commands;

namespace Engine.Rendering.Renderers;

public abstract class RendererBase : IRenderer
{
    protected IContext Context { get; }
    protected ICommandQueue? CommandQueue { get; }
    protected ICommandHandler CommandHandler { get; }

    protected RendererBase(IContext context, ICommandQueue? commandQueue, ICommandHandler commandHandler)
    {
        Context = context ?? throw new ArgumentNullException(nameof(context));
        CommandHandler = commandHandler ?? throw new ArgumentNullException(nameof(commandHandler));
        CommandQueue = commandQueue;
    }

    /// <summary>
    ///     Renders all commands groups in the queue.
    /// </summary>
    public void Render()
    {
        if (CommandQueue == null)
        {
            return;
        }

        if (!CommandQueue.IsReady)
        {
            return;
        }

        BeginRender();
        while (CommandQueue.TryDequeue(out var command))
        {
            CommandHandler.Handle(Context, command!);
        }

        EndRender();
    }

    /// <summary>
    ///     Renders all commands from the given queue.
    /// </summary>
    /// <param name="commandQueue">A queue with commands to render.</param>
    public void Render(ICommandQueue commandQueue)
    {
        if (!commandQueue.IsReady)
        {
            return;
        }

        BeginRender();
        while (commandQueue.TryDequeue(out var command))
        {
            CommandHandler.Handle(Context, command!);
        }

        EndRender();
    }

    public void Dispose() => CommandQueue?.Dispose();

    public virtual void BeginRender()
    {
    }

    public virtual void EndRender()
    {
    }
}
