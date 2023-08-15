#version 450 core

// Input from Vertex Shader
in vec4 v_MaterialColorOut;
in vec4 v_DefaultColorOut;
in vec4 v_VertexColorOut;
in vec2 v_TextureCoordOut;

// Output to Framebuffer
out vec4 fragColor;

// Texture sampler units
uniform sampler2D texUnits[10]; // Array von Textureinheiten

void main()
{
    vec4 diffuseColor = texture(texUnits[0], v_TextureCoordOut);
    vec4 detailColor = texture(texUnits[1], v_TextureCoordOut);
    vec4 metallicColor = texture(texUnits[5], v_TextureCoordOut);
    vec4 normalColor = texture(texUnits[6], v_TextureCoordOut);
    vec4 heightColor = texture(texUnits[7], v_TextureCoordOut);
    vec4 emissionColor = texture(texUnits[8], v_TextureCoordOut);
    vec4 detailMaskColor = texture(texUnits[9], v_TextureCoordOut);

    // Calculate final color of all stages
    vec4 resultColor = diffuseColor * detailColor * metallicColor * v_VertexColorOut;

    if (diffuseColor.a < 0.001) {
        discard;
    }
    fragColor = diffuseColor;
}
