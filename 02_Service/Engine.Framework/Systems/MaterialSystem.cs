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
                commandQueue.Enqueue(new BindShaderProgramCommand(material.Shader.InternalShaderProgram));
                commandQueue.Enqueue(new BindUniformBufferCommand(_materialUniformBuffer));
                commandQueue.Enqueue(new BindTextureCommand(material.Diffuse.InternalTexture, TextureUnit.DiffuseColor));

                if (material.Detail.HasValue)
                {
                    commandQueue.Enqueue(new BindTextureCommand(material.Detail.Value.InternalTexture, TextureUnit.DetailColor));
                }

                if (material.Metallic.HasValue)
                {
                    commandQueue.Enqueue(new BindTextureCommand(material.Metallic.Value.InternalTexture, TextureUnit.MetallicColor));
                }

                if (material.Normal.HasValue)
                {
                    commandQueue.Enqueue(new BindTextureCommand(material.Normal.Value.InternalTexture, TextureUnit.NormalColor));
                }

                if (material.Height.HasValue)
                {
                    commandQueue.Enqueue(new BindTextureCommand(material.Height.Value.InternalTexture, TextureUnit.HeightColor));
                }

                if (material.Emission.HasValue)
                {
                    commandQueue.Enqueue(new BindTextureCommand(material.Emission.Value.InternalTexture, TextureUnit.EmissionColor));
                }

                if (material.DetailMask.HasValue)
                {
                    commandQueue.Enqueue(new BindTextureCommand(material.DetailMask.Value.InternalTexture, TextureUnit.DetailMaskColor));
                }

                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(stage), stage, null);
        }
    }

    public override void Dispose() => _materialUniformBuffer.Dispose();
}
