using Engine.Core.Driver.Graphics.Buffers;

namespace Engine.Rendering.Commands.ShaderCommands;

public sealed class BindUniformBufferCommand : CommandBase
{
    public IUniformBuffer UniformBuffer { get; set; }

    public BindUniformBufferCommand(IUniformBuffer uniformBuffer)
        : base(CommandType.BindUniformBuffer)
    {
        UniformBuffer = uniformBuffer;
    }
}
