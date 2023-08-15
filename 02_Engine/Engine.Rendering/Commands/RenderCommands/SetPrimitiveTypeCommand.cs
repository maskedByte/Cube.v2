using Engine.Core.Driver;
using Engine.Core.Rendering.Commands;

namespace Engine.Rendering.Commands.RenderCommands;

public sealed class SetPrimitiveTypeCommand : CommandBase
{
    public PrimitiveType PrimitiveType { get; }

    public SetPrimitiveTypeCommand(PrimitiveType primitiveType)
        : base(CommandType.SetPrimitiveType)
    {
        PrimitiveType = primitiveType;
    }
}
