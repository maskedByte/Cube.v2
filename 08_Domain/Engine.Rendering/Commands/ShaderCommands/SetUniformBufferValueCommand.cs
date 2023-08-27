namespace Engine.Rendering.Commands.ShaderCommands;

public class SetUniformBufferValueCommand<T> : SetUniformBufferValueCommandBase
{
    public string UniformName { get; }

    public T Value { get; }

    public SetUniformBufferValueCommand(string uniformName, T value)
        : base(typeof(T))
    {
        UniformName = uniformName;
        Value = value;
    }
}
