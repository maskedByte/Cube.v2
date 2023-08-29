using Engine.Core.Driver;
using Engine.Framework.Entities;
using Engine.Rendering.Commands;

namespace Engine.Framework.Systems;

public abstract class SystemBase<TComponent> : ISystem
{
    public IContext Context { get; }

    protected SystemBase(IContext context)
    {
        ArgumentNullException.ThrowIfNull(context);
        Context = context;
    }

    public abstract void Handle(SystemStage stage, IComponent component, ICommandQueue commandQueue, float deltaTime);

    public Type GetCanHandle() => typeof(TComponent);

    public virtual void Dispose()
    {
    }
}
