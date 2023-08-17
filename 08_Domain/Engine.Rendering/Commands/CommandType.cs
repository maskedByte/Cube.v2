namespace Engine.Rendering.Commands;

public enum CommandType
{
    NullCommand,
    ProcessCommand,

    BindShaderProgram,
    BindTexture,
    BindBufferArray,
    BindUniformBuffer,

    SetUniformBufferValue,
    SetShaderUniform,
    SetPrimitiveType,
    SetIndexCount,

    RenderElement
}
