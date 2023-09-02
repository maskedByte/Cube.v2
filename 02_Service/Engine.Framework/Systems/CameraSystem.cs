﻿using Engine.Core.Driver;
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
public sealed class CameraSystem : SystemBase<CameraComponent>
{
    private readonly IUniformBuffer _cameraUniformBuffer;
    private readonly BindUniformBufferCommand _commandCache;

    /// <summary>
    ///     Creates a new instance of the <see cref="CameraSystem" /> class
    ///     to handle entities with a <see cref="CameraComponent" />.
    /// </summary>
    /// <param name="context">The graphics device context.</param>
    public CameraSystem(IContext context)
        : base(context)
    {
        _cameraUniformBuffer = Context.CreateUniformBuffer(
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

        context.RegisterUniformBuffer(_cameraUniformBuffer);
        _commandCache = new BindUniformBufferCommand(_cameraUniformBuffer);
    }

    public override void Handle(SystemStage stage, IComponent component, ICommandQueue commandQueue, float deltaTime)
    {
        switch (stage)
        {
            case SystemStage.Start:
                break;
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
                commandQueue.Enqueue(_commandCache);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(stage), stage, null);
        }
    }

    public override void Dispose() => _cameraUniformBuffer.Dispose();
}
