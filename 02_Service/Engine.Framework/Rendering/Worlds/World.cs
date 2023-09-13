using Engine.Core.Driver;
using Engine.Core.Math.Base;
using Engine.Framework.Components;
using Engine.Framework.Entities;
using Engine.Framework.Rendering.DataStructures;
using Engine.Framework.Rendering.DataStructures.Lights;
using Engine.Framework.Systems;
using Engine.Framework.Systems.LightSystems;
using Engine.Rendering.Commands;
using Engine.Rendering.Renderers;

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

namespace Engine.Framework.Rendering.Worlds;

public sealed class World : IDisposable
{
    private readonly List<IEntity> _entities;
    private readonly Dictionary<Type, ISystem> _systems;
    private readonly Dictionary<Guid, ICommandQueue> _entityCommandQueue;
    private bool _firstRun;

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
    public AmbientLight AmbientLight { get; set; }

    /// <summary>
    ///     Gets or sets the renderer.
    /// </summary>
    public RendererBase Renderer { get; set; }

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
        _entityCommandQueue = new Dictionary<Guid, ICommandQueue>();
        _firstRun = true;

        Core = core ?? throw new ArgumentNullException(nameof(core));
        Context = core.ActiveDriver.GetContext() ?? throw new Exception("No context found.");
        Time = core.ActiveDriver.GetTime();

        Transform = new Transform();
        CommandHandler = new CommandHandler();
        Renderer = new ForwardRenderer(Context, null, CommandHandler);

        // Add default systems.
        AddSystem(new TransformSystem(Context));
        AddSystem(new CameraSystem(Context));
        AddSystem(new MeshSystem(Context));
        AddSystem(new MaterialSystem(Context));

        AddSystem(new AmbientLightSystem(Context));
        AddSystem(new DirectionalLightSystem(Context));

        // AddSystem(new LightSystem<DirectionalLight>(Context));
        // AddSystem(new LightSystem<PointLight>(Context));
        // AddSystem(new LightSystem<SpotLight>(Context));

        //AddSystem(new PhysicsSystem(Context));
        //AddSystem(new ParticleSystem(Context));
        //AddSystem(new AnimationSystem(Context));
        //AddSystem(new AudioSystem(Context));
        //AddSystem(new ScriptSystem(Context));

        // Defaults
        _defaultMaterial = new Material();

        // Create default
        var entity = CreateEntity("World-Entity");
        AmbientLight = entity.AddComponent<AmbientLightComponent>().Light;
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
        _entityCommandQueue.Add(entity.Id, new CommandQueue());

        return entity;
    }

    /// <summary>
    ///     Removes an entity from the world.
    /// </summary>
    /// <param name="entity">The entity to remove.</param>
    public void RemoveEntity(IEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        _entities.Remove(entity);
        _entityCommandQueue.Remove(entity.Id);
    }

    /// <summary>
    ///     Adds a system to handle a specific component type.
    /// </summary>
    /// <param name="instance">The system instance.</param>
    public void AddSystem<T>(SystemBase<T> instance) => _systems.Add(instance.GetCanHandle(), instance);

    /// <summary>
    ///     Updates the world.
    /// </summary>
    public void Update()
    {
        Core.ActiveDriver.Clear();
        Core.ActiveDriver.HandleEvents();

        if (_firstRun)
        {
            foreach (var entity in _entities)
            {
                var entityCommandQueue = _entityCommandQueue[entity.Id];
                entityCommandQueue.Begin();
                foreach (var component in entity.Components.Where(x => _systems.ContainsKey(x.Key)))
                {
                    _systems[component.Key].Handle(SystemStage.Start, component.Value, entityCommandQueue, Time.DeltaTime);
                }
            }

            _firstRun = false;
        }

        foreach (var entity in _entities.Where(e => e.IsActive))
        {
            var entityCommandQueue = _entityCommandQueue[entity.Id];
            entityCommandQueue.Begin();
            foreach (var component in entity.Components.Where(x => _systems.ContainsKey(x.Key)))
            {
                _systems[component.Key].Handle(SystemStage.Update, component.Value, entityCommandQueue, Time.DeltaTime);
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
            var entityCommandQueue = _entityCommandQueue[entity.Id];
            foreach (var component in entity.Components.Where(x => _systems.ContainsKey(x.Key)))
            {
                _systems[component.Key].Handle(SystemStage.Render, component.Value, entityCommandQueue, Time.DeltaTime);
            }

            entityCommandQueue.End();

            Renderer.Render(entityCommandQueue);
            Context.ResetState();
        }

        Core.ActiveDriver.Swap();
    }

    ~World()
    {
        Dispose();
    }

    public void Dispose()
    {
        Core.Dispose();
        CommandHandler.Dispose();
        Renderer.Dispose();

        GC.SuppressFinalize(this);
    }
}
