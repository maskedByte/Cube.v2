using Engine.Core.Driver.Graphics.Buffers;

namespace Engine.Rendering.Commands.RenderCommands;

public sealed class BindBufferArrayCommand : CommandBase
{
    public IBufferArray BufferArray { get; }

    public BindBufferArrayCommand(IBufferArray bufferArray)
        : base(CommandType.BindBufferArray)
    {
        BufferArray = bufferArray;
    }
}
