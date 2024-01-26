using Engine.Core.Driver;
using Engine.Framework.Components;
using Engine.Framework.Entities;
using Engine.Rendering.Commands;

namespace Engine.Framework.Systems;

public class SpriteRenderingSystem : SystemBase<SpriteRendererComponent>
{
    public SpriteRenderingSystem(IContext context)
        : base(context)
    {
    }

    public override void Handle(SystemStage stage, IComponent component, ICommandQueue commandQueue, float deltaTime)
    {
        var materialComponent = (MaterialComponent)component;
        var material = materialComponent.Material;
    }
}
