namespace Engine.Core.Rendering.Commands;

public enum CommandType
{
    NullCommand,

    BindShaderProgram,
    BindTexture,
    BindBufferArray,
    BindUniformBuffer,

    SetShaderUniform,
    SetPrimitiveType,
    SetIndexCount,

    RenderElement
}
