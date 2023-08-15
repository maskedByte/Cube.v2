using Engine.Core.Driver.Graphics.Buffers;
using Engine.Core.Rendering.Commands;

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
