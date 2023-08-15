namespace Engine.Core.Rendering.Commands;

public enum CommandType
{
    BindShaderProgram,
    SetShaderUniform,
    BindTexture,
    BindVertexArray,
    BindUniformBuffer,
    SetPrimitiveType,
    RenderElement,
    SetIndexCount
}
