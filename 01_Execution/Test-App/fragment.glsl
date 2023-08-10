#version 450 core

in vec4 v_VertexColorOut;

out vec4 FragColor;

void main()
{
   FragColor = v_VertexColorOut;
}
