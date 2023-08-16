namespace Engine.Rendering.Commands.ShaderCommands;

/// <summary>
///     Maybe this should be replaced with an explicit command for each type of uniform, because of the type safety and
///     performance.
/// </summary>
public sealed class SetShaderUniformCommand<T> : SetShaderUniformCommandBase
{
    public string UniformName { get; }

    public T Value { get; }

    public SetShaderUniformCommand(string uniformName, T value)
        : base(typeof(T))
    {
        UniformName = uniformName;
        Value = value;
    }
}

public abstract class SetShaderUniformCommandBase : CommandBase
{
    public Type ValueType { get; }

    protected SetShaderUniformCommandBase(Type valueType)
        : base(CommandType.SetShaderUniform)
    {
        ValueType = valueType;
    }
}
