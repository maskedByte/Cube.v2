#version 450 core

layout (location = 0) in vec4 a_Position;
layout (location = 1) in vec4 a_Color;
layout (location = 2) in vec2 a_TexCoord;

layout (std140) uniform Matrices
{
    mat4 m_ViewMatrix;
    mat4 m_ProjectionMatrix;
};

layout (std140, binding = 1) uniform Model
{
    mat4 m_ModelMatrix;
    vec4 v_DefaultColor;
    vec4 v_MaterialColor;
};

layout (std140, binding = 2) uniform UVOffsets
{
    vec2 v_UVOffset;
};

// Output to Fragment Shader
out vec4 v_MaterialColorOut;
out vec4 v_DefaultColorOut;
out vec4 v_VertexColorOut;
out vec2 v_TextureCoordOut;

void main()
{
    gl_Position = a_Position;

    v_MaterialColorOut = v_MaterialColor;
    v_DefaultColorOut = v_DefaultColor;
    v_VertexColorOut = a_Color;
    v_TextureCoordOut = a_TexCoord + v_UVOffset;
}
