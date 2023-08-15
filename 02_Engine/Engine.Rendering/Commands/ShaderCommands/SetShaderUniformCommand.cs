using Engine.Core.Rendering.Commands;

namespace Engine.Rendering.Commands.ShaderCommands;

/// <summary>
///     Maybe this should be replaced with an explicit command for each type of uniform, because of the type safety and
///     performance.
/// </summary>
public sealed class SetShaderUniformCommand<T> : CommandBase
{
    public string UniformName { get; }

    public T Value { get; }

    public Type ValueType => typeof(T);

    public SetShaderUniformCommand(string uniformName, T value)
        : base(CommandType.SetShaderUniform)
    {
        UniformName = uniformName;
        Value = value;
    }
}
