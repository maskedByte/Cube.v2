namespace Engine.Rendering.Commands;

public enum CommandType
{
    NullCommand,
    Process,

    BindShaderProgram,
    BindTexture,
    BindBufferArray,
    BindUniformBuffer,

    SetUniformBufferValue,
    SetShaderUniform,
    SetPrimitiveType,
    SetIndexCount,

    RenderElement,
    SetViewport
}
