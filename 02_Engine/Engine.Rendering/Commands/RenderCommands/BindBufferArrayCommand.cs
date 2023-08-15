using Engine.Core.Driver.Graphics.Buffers;
using Engine.Core.Rendering.Commands;

namespace Engine.Rendering.Commands.RenderCommands;

public sealed class BindBufferArrayCommand : CommandBase
{
    private readonly IBufferArray _bufferArray;

    public BindBufferArrayCommand(IBufferArray bufferArray)
        : base(CommandType.BindVertexArray)
    {
        _bufferArray = bufferArray;
    }
}
