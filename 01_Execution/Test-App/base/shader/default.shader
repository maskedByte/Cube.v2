:Config
{
    Version="#version 450 core";
}

:Shader(Type="Vertex")
{
    layout (location = 0) in vec4 a_Position;
    layout (location = 1) in vec4 a_Color;
    layout (location = 2) in vec2 a_TexCoord;
    layout (location = 3) in vec2 a_Normal;

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

    // Main shader function
    void main()
    {
        gl_Position =  m_ProjectionMatrix * m_ViewMatrix * m_ModelMatrix * a_Position;

        v_MaterialColorOut = v_MaterialColor;
        v_DefaultColorOut = v_DefaultColor;
        v_VertexColorOut = a_Color;
        v_TextureCoordOut = a_TexCoord + v_UVOffset;
    }
}

:Shader(Type="Fragment")
{
    // Input from Vertex Shader
    in vec4 v_MaterialColorOut;
    in vec4 v_DefaultColorOut;
    in vec4 v_VertexColorOut;
    in vec2 v_TextureCoordOut;

    // Output to Framebuffer
    out vec4 fragColor;

    // Texture sampler units
    uniform sampler2D texUnits[10]; // Array von Textureinheiten

    // Main shader function
    void main()
    {
        vec4 diffuseColor = texture(texUnits[0], v_TextureCoordOut);
        vec4 detailColor = texture(texUnits[1], v_TextureCoordOut);
        vec4 metallicColor = texture(texUnits[5], v_TextureCoordOut);
        vec4 normalColor = texture(texUnits[6], v_TextureCoordOut);
        vec4 heightColor = texture(texUnits[7], v_TextureCoordOut);
        vec4 emissionColor = texture(texUnits[8], v_TextureCoordOut);
        vec4 detailMaskColor = texture(texUnits[9], v_TextureCoordOut);

        vec4 texColor = diffuseColor * v_DefaultColorOut * v_MaterialColorOut * v_VertexColorOut;

        if (texColor.a < 0.001) {
            discard;
        }
        fragColor = texColor;
    }
}
