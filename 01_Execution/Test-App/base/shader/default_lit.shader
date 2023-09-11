:Config
{
    Version="#version 450 core";
}

:Shader(Type="Vertex")
{
    layout (location = 0) in vec4 a_Position;
    layout (location = 1) in vec4 a_Color;
    layout (location = 2) in vec2 a_TexCoord;
    layout (location = 3) in vec3 a_Normal;

    layout (std140, binding = 0) uniform Matrices
    {
        mat4 m_ViewMatrix;
        mat4 m_ProjectionMatrix;
    };

    layout (std140, binding = 1) uniform Model
    {
        mat4 m_ModelMatrix;
        mat3 m_NormalMatrix;
    };

    layout (std140, binding = 2) uniform Material
    {
        vec4 v_MaterialColor;
        vec4 v_DefaultColor;
        vec2 v_Tiling;
    };

    // Output to Fragment Shader
    out vec4 v_MaterialColorOut;
    out vec4 v_DefaultColorOut;
    out vec4 v_VertexColorOut;
    out vec2 v_TextureCoordOut;

    // For lighting
    out vec4 v_FragmentPos;
    out vec3 v_NormalOut;

    // Main shader function
    void main()
    {
        v_FragmentPos = m_ModelMatrix * a_Position;
        gl_Position = m_ProjectionMatrix * m_ViewMatrix * m_ModelMatrix * a_Position;

        v_NormalOut = m_NormalMatrix * a_Normal;
        v_MaterialColorOut = v_MaterialColor;
        v_DefaultColorOut = v_DefaultColor;
        v_VertexColorOut = a_Color;
        v_TextureCoordOut = a_TexCoord * v_Tiling;
    }
}

:Shader(Type="Fragment")
{
    struct AmbientLightContract
    {
        vec4 v_Color;
        float f_Intensity;
    };

    struct DirectionalLightContract
    {
        vec4 v_Color;
        float f_Intensity;
        float f_DiffuseIntensity;
        vec3 v_Direction;
    };

    layout (std140, binding = 3) uniform AmbientLightUniform
    {
        AmbientLightContract AmbientLight;
    };

    layout (std140, binding = 4) uniform DirectionalLightUniform
    {
        DirectionalLightContract DirectionalLight;
    };

    // Input from Vertex Shader
    in vec4 v_VertexColorOut;
    in vec2 v_TextureCoordOut;
    in vec4 v_MaterialColorOut;
    in vec4 v_DefaultColorOut;

    in vec4 v_FragmentPos;
    in vec3 v_NormalOut;

    // Texture sampler units
    uniform sampler2D texUnits[10];

    // Output to Framebuffer
    out vec4 fragColor;

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

        // Calculate texture color
        vec4 texColor = diffuseColor * v_VertexColorOut * v_MaterialColorOut * v_DefaultColorOut;

        // Calculate lighting
        vec4 AmbientLightColor = AmbientLight.v_Color * AmbientLight.f_Intensity;
        vec3 lightDir = normalize(-DirectionalLight.v_Direction);
        float diff = max(dot(v_NormalOut, lightDir), 0.0);
        vec4 DirectionalLight = diff * DirectionalLight.v_Color * DirectionalLight.f_Intensity;
        // vec3 lightDir = normalize(lightPos - FragPos);  // Not for Directional Light

        if (texColor.a < 0.001) {
            discard;
        }

        // Calculate final color
        fragColor = (AmbientLightColor + DirectionalLight) * texColor;
    }
}
