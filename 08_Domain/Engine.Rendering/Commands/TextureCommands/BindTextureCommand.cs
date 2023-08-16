using Engine.Core.Driver.Graphics.Textures;

namespace Engine.Rendering.Commands.TextureCommands;

public class BindTextureCommand : CommandBase
{
    public uint TextureUnit { get; }
    public ITexture Texture { get; }

    public BindTextureCommand(ITexture texture, TextureUnit textureUnit)
        : base(CommandType.BindTexture)
    {
        Texture = texture;
        TextureUnit = (uint)textureUnit;
    }
}
