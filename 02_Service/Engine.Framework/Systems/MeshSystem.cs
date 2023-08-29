using Engine.Core.Driver;
using Engine.Core.Driver.Graphics.Buffers;
using Engine.Core.Driver.Graphics.Shaders;
using Engine.Framework.Components;
using Engine.Framework.Entities;
using Engine.Rendering.Commands;
using Engine.Rendering.Commands.RenderCommands;
using Engine.Rendering.Commands.ShaderCommands;

namespace Engine.Framework.Systems;

public sealed class MeshSystem : SystemBase<MeshComponent>
{
    private readonly IUniformBuffer _modelUniformBuffer;

    /// <summary>
    ///     Creates a new instance of the <see cref="MeshSystem" /> class to handle entities with  a
    ///     <see cref="MeshComponent" />.
    /// </summary>
    /// <param name="context"></param>
    public MeshSystem(IContext context)
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
    }

    public override void Handle(SystemStage stage, IComponent component, ICommandQueue commandQueue, float deltaTime)
    {
        var meshComponent = (MeshComponent)component;
        var mesh = meshComponent.Mesh;

        switch (stage)
        {
            case SystemStage.Start:
                mesh.Build();
                break;
            case SystemStage.Update:
                _modelUniformBuffer.SetUniformData("m_ModelMatrix", meshComponent.Owner.Transform.Transformation);
                break;
            case SystemStage.Render:
                commandQueue.Enqueue(new BindUniformBufferCommand(_modelUniformBuffer));
                commandQueue.Enqueue(new BindBufferArrayCommand(mesh.BufferArray));
                commandQueue.Enqueue(new SetPrimitiveTypeCommand(meshComponent.PrimitiveType));
                commandQueue.Enqueue(new SetIndexCountCommand(mesh.IndexCount));
                commandQueue.Enqueue(new DrawElementsCommand());
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(stage), stage, null);
        }
    }

    public override void Dispose() => _modelUniformBuffer.Dispose();
}
