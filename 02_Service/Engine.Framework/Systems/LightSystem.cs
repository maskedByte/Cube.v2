using Engine.Core.Driver;
using Engine.Core.Driver.Graphics.Buffers;
using Engine.Core.Driver.Graphics.Shaders;
using Engine.Core.Math.Base;
using Engine.Core.Math.Vectors;
using Engine.Framework.Components;
using Engine.Framework.Entities;
using Engine.Rendering.Commands;
using Engine.Rendering.Commands.ShaderCommands;

namespace Engine.Framework.Systems;

public class LightSystem : SystemBase<LightComponent>
{
    private readonly IUniformBuffer _lightUniformBuffer;
    private readonly BindUniformBufferCommand _bindUniformBufferCommand;

    public LightSystem(IContext context)
        : base(context)
    {
        _lightUniformBuffer = context.CreateUniformBuffer(
            "Lighting",
            new BufferLayout(
                new[]
                {
                    new BufferElement(0, "v_AmbientColor", ShaderDataType.Vector4),
                    new BufferElement(1, "v_AmbientStrength", ShaderDataType.Float),
                    new BufferElement(2, "v_LightPos", ShaderDataType.Vector3),
                    new BufferElement(3, "v_lightColor", ShaderDataType.Vector4)
                }
            ),
            3
        );

        context.RegisterUniformBuffer(_lightUniformBuffer);
        _bindUniformBufferCommand = new BindUniformBufferCommand(_lightUniformBuffer);
    }

    public override void Handle(SystemStage stage, IComponent component, ICommandQueue commandQueue, float deltaTime)
    {
        var lightComponent = (LightComponent)component;
        var worldAmbientColor = lightComponent.Owner.World.AmbientLight;
        var transform = lightComponent.Owner.GetComponent<TransformComponent>();

        switch (stage)
        {
            case SystemStage.Start:
                break;
            case SystemStage.Update:
                commandQueue.Enqueue(_bindUniformBufferCommand);
                commandQueue.Enqueue(new SetUniformBufferValueCommand<Color>("v_AmbientColor", worldAmbientColor));
                commandQueue.Enqueue(new SetUniformBufferValueCommand<float>("v_AmbientStrength", lightComponent.Intensity));
                commandQueue.Enqueue(new SetUniformBufferValueCommand<Vector3>("v_LightPos", transform!.Transform.Position));
                commandQueue.Enqueue(new SetUniformBufferValueCommand<Color>("v_lightColor", lightComponent.Color));

                break;
            case SystemStage.Render:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(stage), stage, null);
        }
    }
}
