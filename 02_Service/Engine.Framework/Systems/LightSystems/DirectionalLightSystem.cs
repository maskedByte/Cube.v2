using Engine.Core.Driver;
using Engine.Core.Driver.Graphics.Buffers;
using Engine.Core.Driver.Graphics.Shaders;
using Engine.Core.Logging;
using Engine.Core.Math.Base;
using Engine.Core.Math.Vectors;
using Engine.Framework.Components;
using Engine.Framework.Entities;
using Engine.Rendering.Commands;
using Engine.Rendering.Commands.ShaderCommands;

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

namespace Engine.Framework.Systems.LightSystems;

public class DirectionalLightSystem : SystemBase<DirectionalLightComponent>
{
    private readonly IUniformBuffer _lightUniformBuffer;
    private readonly BindUniformBufferCommand _bindLightUniformBufferCommand;

    public DirectionalLightSystem(IContext context)
        : base(context)
    {
        _lightUniformBuffer = context.CreateUniformBuffer(
            "DirectionalLightUniform",
            new BufferLayout(
                new[]
                {
                    new BufferElement(0, "v_Color", ShaderDataType.Vector4),
                    new BufferElement(1, "f_Intensity", ShaderDataType.Float),
                    new BufferElement(2, "f_DiffuseIntensity", ShaderDataType.Float),
                    new BufferElement(3, "v_Direction", ShaderDataType.Vector3, true)
                }
            ),
            3
        );

        context.RegisterUniformBuffer(_lightUniformBuffer);
        _bindLightUniformBufferCommand = new BindUniformBufferCommand(_lightUniformBuffer);
    }

    public override void Handle(SystemStage stage, IComponent component, ICommandQueue commandQueue, float deltaTime)
    {
        if (component is not DirectionalLightComponent lightComponent)
        {
            Log.LogMessageAsync($"The component must be of type {nameof(AmbientLightComponent)}.", LogLevel.Error, this);
            return;
        }

        switch (stage)
        {
            case SystemStage.Start:
                break;
            case SystemStage.Update:
                var worldAmbient = component.Owner.World.AmbientLight;

                commandQueue.Enqueue(_bindLightUniformBufferCommand);
                var transform = component.Owner.GetComponent<TransformComponent>();

                commandQueue.Enqueue(new SetUniformBufferValueCommand<Color>("v_Color", worldAmbient.Color));
                commandQueue.Enqueue(new SetUniformBufferValueCommand<float>("f_Intensity", lightComponent.Light.Intensity));
                commandQueue.Enqueue(new SetUniformBufferValueCommand<float>("f_DiffuseIntensity", lightComponent.Light.DiffuseIntensity));
                commandQueue.Enqueue(new SetUniformBufferValueCommand<Vector3>("v_Direction", transform!.Transform.Forward.Normalized()));

                break;
            case SystemStage.Render:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(stage), stage, null);
        }
    }

    public override void Dispose() => _lightUniformBuffer.Dispose();
}
