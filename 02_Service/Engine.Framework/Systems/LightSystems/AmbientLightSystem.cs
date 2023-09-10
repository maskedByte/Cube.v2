using Engine.Core.Driver;
using Engine.Core.Driver.Graphics.Buffers;
using Engine.Core.Driver.Graphics.Shaders;
using Engine.Core.Logging;
using Engine.Core.Math.Base;
using Engine.Framework.Components;
using Engine.Framework.Entities;
using Engine.Rendering.Commands;
using Engine.Rendering.Commands.ShaderCommands;

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

namespace Engine.Framework.Systems.LightSystems;

public class AmbientLightSystem : SystemBase<AmbientLightComponent>
{
    private readonly IUniformBuffer _ambientLightUniformBuffer;
    private readonly BindUniformBufferCommand _bindAmbientLightUniformBufferCommand;

    public AmbientLightSystem(IContext context)
        : base(context)
    {
        _ambientLightUniformBuffer = context.CreateUniformBuffer(
            "AmbientLightUniform",
            new BufferLayout(
                new[]
                {
                    new BufferElement(0, "v_Color", ShaderDataType.Vector4),
                    new BufferElement(1, "f_Intensity", ShaderDataType.Float)
                }
            ),
            3
        );

        context.RegisterUniformBuffer(_ambientLightUniformBuffer);
        _bindAmbientLightUniformBufferCommand = new BindUniformBufferCommand(_ambientLightUniformBuffer);
    }

    public override void Handle(SystemStage stage, IComponent component, ICommandQueue commandQueue, float deltaTime)
    {
        var lightComponent = component as AmbientLightComponent;
        if (lightComponent == null)
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

                commandQueue.Enqueue(_bindAmbientLightUniformBufferCommand);
                commandQueue.Enqueue(new SetUniformBufferValueCommand<Color>("v_Color", worldAmbient.Color));
                commandQueue.Enqueue(new SetUniformBufferValueCommand<float>("f_Intensity", lightComponent.Light.Intensity));

                break;
            case SystemStage.Render:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(stage), stage, null);
        }
    }

    public override void Dispose() => _ambientLightUniformBuffer.Dispose();
}
