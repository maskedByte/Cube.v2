namespace Engine.Rendering.Commands.ShaderCommands;

public sealed class SetUniformValueCommand<T> : SetUniformValueCommandBase
{
    public string UniformName { get; }

    public T Value { get; }

    public SetUniformValueCommand(string uniformName, T value)
        : base(typeof(T))
    {
        UniformName = uniformName;
        Value = value;
    }
}
