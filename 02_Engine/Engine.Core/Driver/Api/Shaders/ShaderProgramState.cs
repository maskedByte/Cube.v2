namespace Engine.Driver.Api.Shaders;

/// <summary>
/// Actual state of a shader
/// </summary>
public enum ShaderProgramState
{
    /// <summary>
    /// Shader was just created not compiled and has no issues
    /// </summary>
    New,

    /// <summary>
    /// Shader was compiled and Linked successfully
    /// </summary>
    Compiled,

    /// <summary>
    /// A shader was replaced with a new one
    /// </summary>
    Reload,

    /// <summary>
    /// Shader has some issues while compiling or linking
    /// </summary>
    Failed
}
