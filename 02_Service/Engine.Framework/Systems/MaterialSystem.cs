using Engine.Core.Driver;
using Engine.Core.Driver.Graphics.Buffers;
using Engine.Core.Driver.Graphics.Shaders;
using Engine.Core.Driver.Graphics.Textures;
using Engine.Core.Math.Base;
using Engine.Framework.Components;
using Engine.Framework.Entities;
using Engine.Rendering.Commands;
using Engine.Rendering.Commands.ShaderCommands;
using Engine.Rendering.Commands.TextureCommands;

namespace Engine.Framework.Systems;

public sealed class MaterialSystem : SystemBase<MaterialComponent>
{
    private readonly IUniformBuffer _materialUniformBuffer;
    private BindShaderProgramCommand? _bindShaderProgramCommand;
    private BindUniformBufferCommand? _bindUniformBufferCommand;
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
    }

    public override void Handle(SystemStage stage, IComponent component, ICommandQueue commandQueue, float deltaTime)
    {
        var materialComponent = (MaterialComponent)component;
        var material = materialComponent.Material;

        switch (stage)
        {
            case SystemStage.Start:
            case SystemStage.Update:
                _materialUniformBuffer.SetUniformData("v_MaterialColor", material.Color);
                _materialUniformBuffer.SetUniformData("v_DefaultColor", Color.White);
                _materialUniformBuffer.SetUniformData("v_Tiling", material.Tiling);
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

                if (_bindUniformBufferCommand is null)
                {
                    _bindUniformBufferCommand = new BindUniformBufferCommand(_materialUniformBuffer);
                }
                else
                {
                    _bindUniformBufferCommand.UniformBuffer = _materialUniformBuffer;
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

                if (material.Detail.HasValue)
                {
                    _bindTextureCommand.Texture = material.Detail.Value.InternalTexture;
                    _bindTextureCommand.TextureUnit = (uint)TextureUnit.DetailColor;
                    commandQueue.Enqueue(_bindTextureCommand);
                }

                if (material.Metallic.HasValue)
                {
                    _bindTextureCommand.Texture = material.Metallic.Value.InternalTexture;
                    _bindTextureCommand.TextureUnit = (uint)TextureUnit.MetallicColor;
                    commandQueue.Enqueue(_bindTextureCommand);
                }

                if (material.Normal.HasValue)
                {
                    _bindTextureCommand.Texture = material.Normal.Value.InternalTexture;
                    _bindTextureCommand.TextureUnit = (uint)TextureUnit.NormalColor;
                    commandQueue.Enqueue(_bindTextureCommand);
                }

                if (material.Height.HasValue)
                {
                    _bindTextureCommand.Texture = material.Height.Value.InternalTexture;
                    _bindTextureCommand.TextureUnit = (uint)TextureUnit.HeightColor;
                    commandQueue.Enqueue(_bindTextureCommand);
                }

                if (material.Emission.HasValue)
                {
                    _bindTextureCommand.Texture = material.Emission.Value.InternalTexture;
                    _bindTextureCommand.TextureUnit = (uint)TextureUnit.EmissionColor;
                    commandQueue.Enqueue(_bindTextureCommand);
                }

                if (material.DetailMask.HasValue)
                {
                    _bindTextureCommand.Texture = material.DetailMask.Value.InternalTexture;
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
