using Engine.Core.Driver;
using Engine.Core.Math.Base;
using Engine.Framework.Entities;
using Engine.Framework.Rendering.DataStructures;
using Engine.Framework.Systems;
using Engine.Rendering.Commands;
using Engine.Rendering.Renderers;

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

namespace Engine.Framework.Rendering.Worlds;

public sealed class World : IDisposable
{
    private readonly List<IEntity> _entities;
    private readonly Dictionary<Type, ISystem> _systems;

    private Material _defaultMaterial;

    /// <summary>
    ///     Gets the engine core instance.
    /// </summary>
    public EngineCore Core { get; }

    /// <summary>
    ///     Gets the graphics device context.
    /// </summary>
    public IContext Context { get; }

    /// <summary>
    ///     Gets or sets the world transform.
    /// </summary>
    public Transform Transform { get; set; }

    /// <summary>
    ///     Sets or gets the ambient light color.
    /// </summary>
    public Color AmbientLight { get; set; }

    /// <summary>
    ///     Gets or sets the renderer.
    /// </summary>
    public IRenderer Renderer { get; set; }

    /// <summary>
    ///     Sets or gets the command queue.
    /// </summary>
    public ICommandQueue CommandQueue { get; set; }

    /// <summary>
    ///     Sets or gets the command handler.
    /// </summary>
    public ICommandHandler CommandHandler { get; set; }

    /// <summary>
    ///     Gets or sets the game timer.
    /// </summary>
    public ITime Time { get; set; }

    /// <summary>
    ///     Initializes a new instance of a world witch is the root for all entities.
    /// </summary>
    /// <param name="core"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public World(EngineCore core)
    {
        _entities = new List<IEntity>();
        _systems = new Dictionary<Type, ISystem>();

        Core = core ?? throw new ArgumentNullException(nameof(core));
        Context = core.ActiveDriver.GetContext() ?? throw new Exception("No context found.");
        Time = core.ActiveDriver.GetTime();

        Transform = new Transform();
        AmbientLight = Color.White;
        CommandQueue = new CommandQueue();
        CommandHandler = new CommandHandler();
        Renderer = new ForwardRenderer(Context, CommandQueue, CommandHandler);

        // Add default systems.
        AddSystem(new CameraSystem(Context));

        // Defaults
        _defaultMaterial = new Material();
    }

    /// <summary>
    ///     Creates a new entity in the world.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="parent"></param>
    /// <returns></returns>
    public IEntity CreateEntity(string name = "", IEntity? parent = null)
    {
        var entity = new Entity(this, parent)
        {
            Tag = string.IsNullOrWhiteSpace(name)
                ? $"Entity_{_entities.Count}"
                : name
        };

        _entities.Add(entity);

        return entity;
    }

    /// <summary>
    ///     Add an entity to the world.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <returns>The entity that was added.</returns>
    public IEntity AddEntity(IEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        _entities.Add(entity);

        return entity;
    }

    /// <summary>
    ///     Adds a system to handle a specific component type.
    /// </summary>
    /// <param name="system"></param>
    public void AddSystem(ISystem system) => _systems.Add(system.GetCanHandle(), system);

    /// <summary>
    ///     Updates the world.
    /// </summary>
    public void Update()
    {
        Core.ActiveDriver.Clear();
        Core.ActiveDriver.HandleEvents();
        CommandQueue.Begin();

        foreach (var entity in _entities.Where(e => e.IsActive))
        {
            foreach (var component in entity.Components.Where(x => _systems.ContainsKey(x.Key)))
            {
                _systems[component.Key].Handle(SystemStage.Update, component.Value, CommandQueue, Time.DeltaTime);
            }
        }
    }

    /// <summary>
    ///     Renders the world.
    /// </summary>
    public void Render()
    {
        foreach (var entity in _entities.Where(e => e.IsActive))
        {
            foreach (var component in entity.Components.Where(x => _systems.ContainsKey(x.Key)))
            {
                _systems[component.Key].Handle(SystemStage.Render, component.Value, CommandQueue, Time.DeltaTime);
            }
        }

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
