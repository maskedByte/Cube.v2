using Engine.Core.Driver.Graphics.Buffers;

namespace Engine.Rendering.Commands.RenderCommands;

public sealed class BindUniformBufferCommand : CommandBase
{
    public IUniformBuffer UniformBuffer { get; }

    public BindUniformBufferCommand(IUniformBuffer uniformBuffer)
        : base(CommandType.BindUniformBuffer)
    {
        UniformBuffer = uniformBuffer;
    }
}
