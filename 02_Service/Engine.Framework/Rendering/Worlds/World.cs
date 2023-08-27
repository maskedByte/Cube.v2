using Engine.Core.Driver;
using Engine.Core.Math.Base;
using Engine.Rendering.Commands;
using Engine.Rendering.Renderers;

namespace Engine.Framework.Rendering.Worlds;

public sealed class World : IDisposable
{
    public EngineCore Core { get; }
    public IContext Context { get; }
    public Transform Transform { get; set; }
    public Color AmbientLight { get; set; }
    public IRenderer Renderer { get; set; }
    public ICommandQueue CommandQueue { get; set; }
    public ICommandHandler CommandHandler { get; set; }

    public World(EngineCore core)
    {
        Core = core ?? throw new ArgumentNullException(nameof(core));
        Context = core.ActiveDriver.GetContext()!;
        Transform = new Transform();
        AmbientLight = Color.White;
        CommandQueue = new CommandQueue();
        CommandHandler = new CommandHandler();
        Renderer = new ForwardRenderer(Context, CommandQueue, CommandHandler);
    }

    public void Update()
    {
        Core.ActiveDriver.Clear();
        Core.ActiveDriver.HandleEvents();
        CommandQueue.Begin();

        // TODO: update all entities in the world
    }

    public void Render()
    {
        // TODO: render all entities in the world

        CommandQueue.End();
        Renderer.Render();

        Core.ActiveDriver.Swap();
    }

    ~World()
    {
        Dispose();
    }

    public void Dispose()
    {
        Core.Dispose();
        CommandQueue.Dispose();
        CommandHandler.Dispose();
        Renderer.Dispose();

        GC.SuppressFinalize(this);
    }
}
