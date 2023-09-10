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

public class LightSystem<T> : SystemBase<LightComponentBase<T>>
{
    private readonly IUniformBuffer _ambientLightUniformBuffer;
    private readonly BindUniformBufferCommand _bindAmbientLightUniformBufferCommand;

    public LightSystem(IContext context)
        : base(context)
    {
        _ambientLightUniformBuffer = context.CreateUniformBuffer(
            "AmbientLight",
            new BufferLayout(
                new[]
                {
                    new BufferElement(0, "v_AmbientColor", ShaderDataType.Vector4),
                    new BufferElement(1, "f_AmbientStrength", ShaderDataType.Float)
                }
            ),
            3
        );

        context.RegisterUniformBuffer(_ambientLightUniformBuffer);
        _bindAmbientLightUniformBufferCommand = new BindUniformBufferCommand(_ambientLightUniformBuffer);
    }

    public override void Handle(SystemStage stage, IComponent component, ICommandQueue commandQueue, float deltaTime)
    {
        switch (stage)
        {
            case SystemStage.Start:
                break;
            case SystemStage.Update:
                switch (component)
                {
                    case AmbientLightComponent ambientLightComponent:
                        HandleAmbientLight(ambientLightComponent, commandQueue);
                        break;
                    case DirectionalLightComponent directionalLightComponent:
                        //HandleDirectionalLight(directionalLightComponent, commandQueue);
                        break;
                    case PointLightComponent pointLightComponent:
                        //HandlePointLight(pointLightComponent, commandQueue);
                        break;
                    case SpotLightComponent spotLightComponent:
                        //HandleSpotLight(spotLightComponent, commandQueue);
                        break;
                }

                break;
            case SystemStage.Render:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(stage), stage, null);
        }
    }

    private void HandleAmbientLight(AmbientLightComponent component, ICommandQueue commandQueue)
    {
    }

    private void HandleDirectionalLight(DirectionalLightComponent component, ICommandQueue commandQueue)
    {
        var transform = component.Owner.GetComponent<TransformComponent>();

        commandQueue.Enqueue(new SetUniformBufferValueCommand<Vector3>("v_DirectionalLight.Direction", transform!.Transform.Forward));
        commandQueue.Enqueue(new SetUniformBufferValueCommand<Vector3>("v_DirectionalLight.Position", transform!.Transform.Position));
        commandQueue.Enqueue(new SetUniformBufferValueCommand<Color>("v_Color", component.Light.Color));
        commandQueue.Enqueue(new SetUniformBufferValueCommand<float>("f_Intensity", component.Light.Intensity));
    }

    private void HandlePointLight(PointLightComponent component, ICommandQueue commandQueue)
    {
        var transform = component.Owner.GetComponent<TransformComponent>();

        commandQueue.Enqueue(new SetUniformBufferValueCommand<Vector3>("v_PointLight.Position", transform!.Transform.Position));
        commandQueue.Enqueue(new SetUniformBufferValueCommand<float>("f_PointLight.Radius", component.Light.Radius));
        commandQueue.Enqueue(new SetUniformBufferValueCommand<Color>("v_Color", component.Light.Color));
        commandQueue.Enqueue(new SetUniformBufferValueCommand<float>("f_Intensity", component.Light.Intensity));
    }

    private void HandleSpotLight(SpotLightComponent component, ICommandQueue commandQueue)
    {
        var transform = component.Owner.GetComponent<TransformComponent>();

        commandQueue.Enqueue(new SetUniformBufferValueCommand<Vector3>("v_SpotLight.Position", transform!.Transform.Position));
        commandQueue.Enqueue(new SetUniformBufferValueCommand<Color>("v_SpotLight.Color", component.Light.Color));
        commandQueue.Enqueue(new SetUniformBufferValueCommand<float>("v_SpotLight.Radius", component.Light.Radius));
        commandQueue.Enqueue(new SetUniformBufferValueCommand<float>("v_SpotLightFalloff", component.Light.Falloff));
        commandQueue.Enqueue(new SetUniformBufferValueCommand<Color>("v_Color", component.Light.Color));
        commandQueue.Enqueue(new SetUniformBufferValueCommand<float>("f_Intensity", component.Light.Intensity));
    }

    public override void Dispose() => _ambientLightUniformBuffer.Dispose();
}
