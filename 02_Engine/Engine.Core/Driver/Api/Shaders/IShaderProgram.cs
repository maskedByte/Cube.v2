namespace Engine.Core.Driver.Api.Shaders;

/// <summary>
/// Interface for Shader
/// </summary>
public interface IShaderProgram : IBindable, IDisposable
{
    /// <summary>
    /// Queries the shader parameter to find a matching attribute/uniform.
    /// </summary>
    /// <param name="name">Specifies the case-sensitive name of the shader attribute/uniform.</param>
    /// <returns>The requested attribute/uniform, or null on a failure.</returns>
    IShaderParameter this[string name] { get; }

    /// <summary>
    /// Returns the internal id of the api shader
    /// </summary>
    /// <returns></returns>
    uint GetId();

    /// <summary>
    /// Add a shader to the program
    /// </summary>
    /// <param name="shader">The shader to add</param>
    void AddShader(IShader shader);

    /// <summary>
    /// Get the current state of the shader program
    /// </summary>
    /// <returns>The current state of the shader program <see cref="ShaderProgramState" /></returns>
    ShaderProgramState GetProgramState();

    /// <summary>
    /// Compile and linking shaders
    /// </summary>
    void Compile();

    /// <summary>
    /// Get uniform by <paramref name="name" />
    /// </summary>
    /// <param name="name">The name of the uniform inside the shader</param>
    /// <returns>id of the uniform</returns>
    int GetUniform(string name);

    /// <summary>
    /// Get attribute by <paramref name="name" />
    /// </summary>
    /// <param name="name">The name of the attribute inside the shader</param>
    /// <returns>id of the attribute</returns>
    int GetAttribute(string name);
}
