#version 450 core

layout (location = 0) in vec4 a_Position;
layout (location = 1) in vec4 a_Color;
layout (location = 2) in vec2 a_TexCoord;

out vec4 v_VertexColorOut;

void main()
{
  gl_Position = a_Position;
  v_VertexColorOut = a_Color;
}
