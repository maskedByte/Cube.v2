using Engine.Core.Driver;

namespace Engine.Rendering.Commands.RenderCommands;

public sealed class SetPrimitiveTypeCommand : CommandBase
{
    public PrimitiveType PrimitiveType { get; set; }

    public SetPrimitiveTypeCommand(PrimitiveType primitiveType)
        : base(CommandType.SetPrimitiveType)
    {
        PrimitiveType = primitiveType;
    }
}
