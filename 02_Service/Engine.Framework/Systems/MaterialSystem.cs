using Engine.Core.Driver;
using Engine.Core.Driver.Graphics.Buffers;
using Engine.Core.Driver.Graphics.Shaders;
using Engine.Core.Driver.Graphics.Textures;
using Engine.Core.Math.Base;
using Engine.Core.Math.Vectors;
using Engine.Framework.Components;
using Engine.Framework.Entities;
using Engine.Rendering.Commands;
using Engine.Rendering.Commands.ShaderCommands;
using Engine.Rendering.Commands.TextureCommands;

namespace Engine.Framework.Systems;

public sealed class MaterialSystem : SystemBase<MaterialComponent>
{
    private readonly IUniformBuffer _materialUniformBuffer;
    private readonly BindUniformBufferCommand _bindUniformBufferCommand;
    private BindShaderProgramCommand? _bindShaderProgramCommand;
    private BindTextureCommand? _bindTextureCommand;

    /// <summary>
    ///     Creates a new instance of the <see cref="MaterialSystem" /> class to handle entities with a
    ///     <see cref="MaterialComponent" />.
    /// </summary>
    /// <param name="context">The graphics device context.</param>
    public MaterialSystem(IContext context)
        : base(context)
    {
        _materialUniformBuffer = context.CreateUniformBuffer(
            "Material",
            new BufferLayout(
                new[]
                {
                    new BufferElement(0, "v_MaterialColor", ShaderDataType.Vector4),
                    new BufferElement(1, "v_DefaultColor", ShaderDataType.Vector4),
                    new BufferElement(2, "v_Tiling", ShaderDataType.Vector2)
                }
            ),
            2
        );

        context.RegisterUniformBuffer(_materialUniformBuffer);
        _bindUniformBufferCommand = new BindUniformBufferCommand(_materialUniformBuffer);
    }

    public override void Handle(SystemStage stage, IComponent component, ICommandQueue commandQueue, float deltaTime)
    {
        var materialComponent = (MaterialComponent)component;
        var material = materialComponent.Material;

        switch (stage)
        {
            case SystemStage.Start:
                break;
            case SystemStage.Update:
                commandQueue.Enqueue(_bindUniformBufferCommand);
                commandQueue.Enqueue(new SetUniformBufferValueCommand<Color>("v_MaterialColor", material.Color));
                commandQueue.Enqueue(new SetUniformBufferValueCommand<Color>("v_DefaultColor", Color.White));
                commandQueue.Enqueue(new SetUniformBufferValueCommand<Vector2>("v_Tiling", material.Tiling));

                break;

            case SystemStage.Render:

                if (_bindShaderProgramCommand is null)
                {
                    _bindShaderProgramCommand = new BindShaderProgramCommand(material.Shader.InternalShaderProgram);
                }
                else
                {
                    _bindShaderProgramCommand.ShaderProgram = material.Shader.InternalShaderProgram;
                }

                if (_bindTextureCommand is null)
                {
                    _bindTextureCommand = new BindTextureCommand(material.Diffuse.InternalTexture, TextureUnit.DiffuseColor);
                }
                else
                {
                    _bindTextureCommand.Texture = material.Diffuse.InternalTexture;
                    _bindTextureCommand.TextureUnit = (uint)TextureUnit.DiffuseColor;
                }

                commandQueue.Enqueue(_bindShaderProgramCommand);
                commandQueue.Enqueue(_bindUniformBufferCommand);
                commandQueue.Enqueue(_bindTextureCommand);

                if (material.Detail is not null)
                {
                    _bindTextureCommand.Texture = material.Detail.InternalTexture;
                    _bindTextureCommand.TextureUnit = (uint)TextureUnit.DetailColor;
                    commandQueue.Enqueue(_bindTextureCommand);
                }

                if (material.Metallic is not null)
                {
                    _bindTextureCommand.Texture = material.Metallic.InternalTexture;
                    _bindTextureCommand.TextureUnit = (uint)TextureUnit.MetallicColor;
                    commandQueue.Enqueue(_bindTextureCommand);
                }

                if (material.Normal is not null)
                {
                    _bindTextureCommand.Texture = material.Normal.InternalTexture;
                    _bindTextureCommand.TextureUnit = (uint)TextureUnit.NormalColor;
                    commandQueue.Enqueue(_bindTextureCommand);
                }

                if (material.Height is not null)
                {
                    _bindTextureCommand.Texture = material.Height.InternalTexture;
                    _bindTextureCommand.TextureUnit = (uint)TextureUnit.HeightColor;
                    commandQueue.Enqueue(_bindTextureCommand);
                }

                if (material.Emission is not null)
                {
                    _bindTextureCommand.Texture = material.Emission.InternalTexture;
                    _bindTextureCommand.TextureUnit = (uint)TextureUnit.EmissionColor;
                    commandQueue.Enqueue(_bindTextureCommand);
                }

                if (material.DetailMask is not null)
                {
                    _bindTextureCommand.Texture = material.DetailMask.InternalTexture;
                    _bindTextureCommand.TextureUnit = (uint)TextureUnit.DetailMaskColor;
                    commandQueue.Enqueue(_bindTextureCommand);
                }

                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(stage), stage, null);
        }
    }

    public override void Dispose() => _materialUniformBuffer.Dispose();
}
