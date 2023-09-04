using Engine.Core.Driver;
using Engine.Framework.Components;
using Engine.Framework.Entities;
using Engine.Rendering.Commands;
using Engine.Rendering.Commands.RenderCommands;

namespace Engine.Framework.Systems;

public sealed class MeshSystem : SystemBase<MeshComponent>
{
    private BindBufferArrayCommand? _bindBufferArrayCommand;
    private SetPrimitiveTypeCommand? _setPrimitiveTypeCommand;
    private SetIndexCountCommand? _setIndexCountCommand;
    private readonly DrawElementsCommand _drawElementsCommand;

    /// <summary>
    ///     Creates a new instance of the <see cref="MeshSystem" /> class to handle entities with  a
    ///     <see cref="MeshComponent" />.
    /// </summary>
    /// <param name="context"></param>
    public MeshSystem(IContext context)
        : base(context)
    {
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
                break;
            case SystemStage.Render:
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

    public override void Dispose()
    {
    }
}
