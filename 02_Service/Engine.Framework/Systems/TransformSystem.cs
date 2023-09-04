using Engine.Core.Driver;
using Engine.Core.Driver.Graphics.Buffers;
using Engine.Core.Driver.Graphics.Shaders;
using Engine.Core.Math.Matrices;
using Engine.Framework.Components;
using Engine.Framework.Entities;
using Engine.Rendering.Commands;
using Engine.Rendering.Commands.ShaderCommands;

namespace Engine.Framework.Systems;

public class TransformSystem : SystemBase<TransformComponent>
{
    private readonly BindUniformBufferCommand _modelUniformBufferCommand;
    private readonly IUniformBuffer _modelUniformBuffer;

    public TransformSystem(IContext context)
        : base(context)
    {
        _modelUniformBuffer = context.CreateUniformBuffer(
            "Model",
            new BufferLayout(
                new[]
                {
                    new BufferElement(0, "m_ModelMatrix", ShaderDataType.Matrix4)
                }
            ),
            1
        );

        _modelUniformBufferCommand = new BindUniformBufferCommand(_modelUniformBuffer);
        context.RegisterUniformBuffer(_modelUniformBuffer);
    }

    public override void Handle(SystemStage stage, IComponent component, ICommandQueue commandQueue, float deltaTime)
    {
        var meshComponent = (TransformComponent)component;
        var transform = meshComponent.Transform;

        switch (stage)
        {
            case SystemStage.Start:
                break;
            case SystemStage.Update:
                commandQueue.Enqueue(_modelUniformBufferCommand);
                commandQueue.Enqueue(new SetUniformBufferValueCommand<Matrix4>("m_ModelMatrix", transform.Transformation));
                break;
            case SystemStage.Render:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(stage), stage, null);
        }
    }

    public override void Dispose() => _modelUniformBuffer.Dispose();
}
