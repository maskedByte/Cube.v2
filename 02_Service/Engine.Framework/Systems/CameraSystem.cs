using Engine.Core.Driver;
using Engine.Core.Driver.Graphics.Buffers;
using Engine.Core.Driver.Graphics.Shaders;
using Engine.Framework.Components;
using Engine.Framework.Entities;
using Engine.Framework.Rendering.Cameras;
using Engine.Rendering.Commands;
using Engine.Rendering.Commands.ShaderCommands;

namespace Engine.Framework.Systems;

/// <summary>
///     System for handling cameras entities.
/// </summary>
public sealed class CameraSystem : ISystem
{
    private readonly IContext _context;
    private readonly IUniformBuffer _cameraUniformBuffer;

    /// <summary>
    ///     Creates a new instance of the <see cref="CameraSystem" /> class
    ///     to handle entities with a <see cref="CameraComponent" />.
    /// </summary>
    /// <param name="context">The graphics device context.</param>
    public CameraSystem(IContext context)
    {
        _context = context;

        _cameraUniformBuffer = context.CreateUniformBuffer(
            "Matrices",
            new BufferLayout(
                new[]
                {
                    new BufferElement(0, "m_ViewMatrix", ShaderDataType.Matrix4),
                    new BufferElement(1, "m_ProjectionMatrix", ShaderDataType.Matrix4)
                }
            ),
            0
        );
    }

    public void Handle(SystemStage stage, IComponent component, ICommandQueue commandQueue, float deltaTime)
    {
        switch (stage)
        {
            case SystemStage.Start:
            case SystemStage.Update:
                var cameraComponent = (CameraComponent)component;

                switch (cameraComponent.ProjectionMode)
                {
                    case ProjectionMode.Orthographic:
                        _cameraUniformBuffer.SetUniformData("m_ViewMatrix", cameraComponent.Camera!.Transform.Transformation);
                        _cameraUniformBuffer.SetUniformData(
                            "m_ProjectionMatrix",
                            cameraComponent.Camera.GetProjection(ProjectionMode.Orthographic)
                        );

                        break;
                    case ProjectionMode.Perspective:
                        _cameraUniformBuffer.SetUniformData("m_ViewMatrix", cameraComponent.Camera!.ViewMatrix);
                        _cameraUniformBuffer.SetUniformData(
                            "m_ProjectionMatrix",
                            cameraComponent.Camera.GetProjection(ProjectionMode.Perspective)
                        );

                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                break;
            case SystemStage.Render:
                commandQueue.Enqueue(new BindUniformBufferCommand(_cameraUniformBuffer));
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(stage), stage, null);
        }
    }

    public Type GetCanHandle() => typeof(CameraComponent);

    public void Dispose() => _cameraUniformBuffer.Dispose();
}
