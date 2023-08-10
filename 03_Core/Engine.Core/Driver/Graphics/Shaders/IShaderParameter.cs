using Engine.Core.Math.Base;
using Engine.Core.Math.Matrices;
using Engine.Core.Math.Vectors;

namespace Engine.Core.Driver.Graphics.Shaders;

/// <summary>
///     Interface for <see cref="IShaderParameter" />
/// </summary>
public interface IShaderParameter
{
    /// <summary>
    ///     Specifies the location of the parameter in the OpenGL program.
    /// </summary>
    public int Location { get; }

    /// <summary>
    ///     Specifies the case-sensitive name of the parameter.
    /// </summary>
    public string Name { get; }

    /// <summary>
    ///     Specifies the parameter type (either attribute or uniform).
    /// </summary>
    public ParameterType ParamType { get; }

    /// <summary>
    ///     Specifies the OpenGL program ID.
    /// </summary>
    public uint Program { get; }

    /// <summary>
    ///     Specifies the C# equivalent of the GLSL data type.
    /// </summary>
    public Type Type { get; }

    /// <summary>
    ///     Gets the location of the parameter in a compiled OpenGL program.
    /// </summary>
    /// <param name="shaderProgram">Specifies the shaderProgram program that contains this parameter.</param>
    public void GetLocation(IShaderProgram shaderProgram);

    /// <summary>
    ///     Set value for this parameter
    /// </summary>
    /// <param name="param"><see cref="bool" /> Value to set</param>
    public void SetValue(bool param);

    /// <summary>
    ///     Set value for this parameter
    /// </summary>
    /// <param name="param"><see cref="float" /> Value to set</param>
    public void SetValue(float param);

    /// <summary>
    ///     Set value for this parameter
    /// </summary>
    /// <param name="param"><see cref="float" /> Value to set</param>
    public void SetValue(float[] param);

    /// <summary>
    ///     Set value for this parameter
    /// </summary>
    /// <param name="param"><see cref="int" /> Value to set</param>
    public void SetValue(int param);

    /// <summary>
    ///     Set value for this parameter
    /// </summary>
    /// <param name="param"><see cref="Matrix3" /> Value to set</param>
    public void SetValue(Matrix3 param);

    /// <summary>
    ///     Set value for this parameter
    /// </summary>
    /// <param name="param"><see cref="Matrix4" /> Value to set</param>
    public void SetValue(Matrix4 param);

    /// <summary>
    ///     Set value for this parameter
    /// </summary>
    /// <param name="param"><see cref="Vector2" /> Value to set</param>
    public void SetValue(Vector2 param);

    /// <summary>
    ///     Set value for this parameter
    /// </summary>
    /// <param name="param"><see cref="Vector3" /> Value to set</param>
    public void SetValue(Vector3 param);

    /// <summary>
    ///     Set value for this parameter
    /// </summary>
    /// <param name="param"><see cref="Vector4" /> Value to set</param>
    public void SetValue(Vector4 param);

    /// <summary>
    ///     Set value for this parameter
    /// </summary>
    /// <param name="param"><see cref="Color" /> Value to set</param>
    public void SetValue(Color param);
}
