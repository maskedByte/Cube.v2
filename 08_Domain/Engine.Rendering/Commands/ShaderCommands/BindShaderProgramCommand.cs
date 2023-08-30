using Engine.Core.Driver.Graphics.Shaders;
using Engine.Rendering.Commands.TextureCommands;

namespace Engine.Rendering.Commands.ShaderCommands;

public sealed class BindShaderProgramCommand : CommandBase
{
    public IShaderProgram ShaderProgram { get; }

    public BindShaderProgramCommand(IShaderProgram shaderProgram)
        : base(CommandType.BindShaderProgram)
    {
        ShaderProgram = shaderProgram;
        Priority = (uint)CommandPriority.ShaderBind;
    }
}
