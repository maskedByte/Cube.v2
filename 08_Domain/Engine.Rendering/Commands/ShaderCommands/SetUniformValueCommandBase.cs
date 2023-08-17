namespace Engine.Rendering.Commands.ShaderCommands;

public abstract class SetUniformValueCommandBase : CommandBase
{
    public Type ValueType { get; }

    protected SetUniformValueCommandBase(Type valueType)
        : base(CommandType.SetShaderUniform)
    {
        ValueType = valueType;
    }
}
