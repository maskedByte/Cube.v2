#version 450 core

in vec4 v_VertexColorOut;
in vec2 v_TextureCoordOut;

out vec4 fragColor;

uniform sampler2D texUnit0;

void main()
{
   vec4 texColor = texture(texUnit0, vec2(v_TextureCoordOut.x, v_TextureCoordOut.y)).rgba * v_VertexColorOut;

    if (texColor.a < 0.001) {
        discard;
    }
    fragColor = texColor;
}
