namespace Engine.Rendering.Commands.ShaderCommands;

public abstract class SetUniformBufferValueCommandBase : CommandBase
{
    public Type ValueType { get; }

    protected SetUniformBufferValueCommandBase(Type valueType)
        : base(CommandType.SetUniformBufferValue)
    {
        ValueType = valueType;
    }
}
