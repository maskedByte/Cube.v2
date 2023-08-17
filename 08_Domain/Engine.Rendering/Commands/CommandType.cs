namespace Engine.Rendering.Commands;

public enum CommandType
{
    NullCommand,

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
