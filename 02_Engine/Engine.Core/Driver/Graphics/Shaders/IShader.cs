namespace Engine.Core.Driver.Graphics.Shaders;

public interface IShader : IDisposable
{
    /// <summary>
    /// The compiled status of the shader.
    /// </summary>
    bool Compiled { get; set; }

    /// <summary>
    /// The type of shader.
    /// </summary>
    ShaderSourceType Type { get; }

    /// <summary>
    /// The source code of the shader.
    /// </summary>
    string[] Source { get; }

    /// <summary>
    /// Compiles the shader.
    /// </summary>
    void Compile(bool force = false);

    /// <summary>
    /// Gets the internal id of the shader.
    /// </summary>
    /// <returns>An unsigned integer representing the internal id of the shader.</returns>
    uint GetId();
}
