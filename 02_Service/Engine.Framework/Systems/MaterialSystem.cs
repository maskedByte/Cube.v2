using Engine.Core.Driver;
using Engine.Core.Driver.Graphics.Textures;
using Engine.Framework.Components;
using Engine.Framework.Entities;
using Engine.Rendering.Commands;
using Engine.Rendering.Commands.ShaderCommands;
using Engine.Rendering.Commands.TextureCommands;

namespace Engine.Framework.Systems;

public class MaterialSystem : ISystem
{
    private readonly IContext _context;

    /// <summary>
    ///     Creates a new instance of the <see cref="MaterialSystem" /> class to handle entities with a
    ///     <see cref="MaterialComponent" />.
    /// </summary>
    /// <param name="context"></param>
    public MaterialSystem(IContext context)
    {
        _context = context;
    }

    public void Handle(SystemStage stage, IComponent component, ICommandQueue commandQueue, float deltaTime)
    {
        switch (stage)
        {
            case SystemStage.Start:
            case SystemStage.Update:
                break;
            case SystemStage.Render:
                var materialComponent = (MaterialComponent)component;
                var material = materialComponent.Material;

                commandQueue.Enqueue(new BindShaderProgramCommand(material.Shader.InternalShaderProgram));
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

    public Type GetCanHandle() => typeof(MaterialSystem);

    public void Dispose()
    {
    }
}
