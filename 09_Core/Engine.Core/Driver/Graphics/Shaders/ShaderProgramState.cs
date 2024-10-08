namespace Engine.Core.Driver.Graphics.Shaders;

/// <summary>
///     Actual state of a shader
/// </summary>
public enum ShaderProgramState
{
    /// <summary>
    ///     Shader was just created not compiled and has no issues
    /// </summary>
    New,

    /// <summary>
    ///     Shader was compiled and Linked successfully
    /// </summary>
    Compiled,

    /// <summary>
    ///     Shader has some issues while compiling or linking
    /// </summary>
    Failed
}
