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
    private BindBufferArrayCommand? _bindBufferArrayCommand;
    private SetPrimitiveTypeCommand? _setPrimitiveTypeCommand;
    private SetIndexCountCommand? _setIndexCountCommand;
    private readonly DrawElementsCommand _drawElementsCommand;
    private readonly BindUniformBufferCommand _modelUniformBufferCommand;

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

        _modelUniformBufferCommand = new BindUniformBufferCommand(_modelUniformBuffer);
        context.RegisterUniformBuffer(_modelUniformBuffer);

        _drawElementsCommand = new DrawElementsCommand();
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
                commandQueue.Enqueue(_modelUniformBufferCommand);

                if (_bindBufferArrayCommand is null)
                {
                    _bindBufferArrayCommand = new BindBufferArrayCommand(mesh.BufferArray);
                }
                else
                {
                    _bindBufferArrayCommand.BufferArray = mesh.BufferArray;
                }

                commandQueue.Enqueue(_bindBufferArrayCommand);

                if (_setPrimitiveTypeCommand is null)
                {
                    _setPrimitiveTypeCommand = new SetPrimitiveTypeCommand(meshComponent.PrimitiveType);
                }
                else
                {
                    _setPrimitiveTypeCommand.PrimitiveType = meshComponent.PrimitiveType;
                }

                commandQueue.Enqueue(_setPrimitiveTypeCommand);

                if (_setIndexCountCommand is null)
                {
                    _setIndexCountCommand = new SetIndexCountCommand(mesh.IndexCount);
                }
                else
                {
                    _setIndexCountCommand.IndexCount = mesh.IndexCount;
                }

                commandQueue.Enqueue(_setIndexCountCommand);

                commandQueue.Enqueue(_drawElementsCommand);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(stage), stage, null);
        }
    }

    public override void Dispose() => _modelUniformBuffer.Dispose();
}
