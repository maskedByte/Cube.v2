// ReSharper disable InconsistentNaming

using Engine.Core.Driver.Graphics.Shaders;
using Engine.Core.Math.Base;
using Engine.Core.Math.Matrices;
using Engine.Core.Math.Vectors;
using Engine.OpenGL.Vendor.OpenGL.Core;

namespace Engine.OpenGL.GraphicsApi.Shaders;

/// <summary>
///     Shader parameter class
/// </summary>
internal sealed class GlShaderParameter : IShaderParameter
{
    private readonly float[] _uniformMatrix2;
    private readonly float[] _uniformMatrix3;
    private readonly float[] _uniformMatrix4;

    /// <inheritdoc />
    public Type Type { get; }

    /// <inheritdoc />
    public int Location { get; private set; }

    /// <inheritdoc />
    public uint Program { get; private set; }

    /// <inheritdoc />
    public ParameterType ParamType { get; }

    /// <inheritdoc />
    public string Name { get; }

    /// <summary>
    ///     Creates a program parameter with a given type and name.
    ///     The location must be found after the program is compiled
    ///     by using the GetLocation(ShaderProgram Program) method.
    /// </summary>
    /// <param name="type">Specifies the C# equivalent of the GLSL data type.</param>
    /// <param name="paramType">Specifies the parameter type (either attribute or uniform).</param>
    /// <param name="name">Specifies the case-sensitive name of the parameter.</param>
    public GlShaderParameter(Type type, ParameterType paramType, string name)
    {
        Type = type;
        ParamType = paramType;
        Name = name;
        _uniformMatrix2 = new float[4];
        _uniformMatrix3 = new float[9];
        _uniformMatrix4 = new float[16];
    }

    /// <summary>
    ///     Creates a program parameter with a type, name, program and location.
    /// </summary>
    /// <param name="type">Specifies the C# equivalent of the GLSL data type.</param>
    /// <param name="paramType">Specifies the parameter type (either attribute or uniform).</param>
    /// <param name="name">Specifies the case-sensitive name of the parameter.</param>
    /// <param name="program">Specifies the OpenGL program ID.</param>
    /// <param name="location">Specifies the location of the parameter.</param>
    public GlShaderParameter(
        Type type,
        ParameterType paramType,
        string name,
        uint program,
        int location
    )
        : this(type, paramType, name)
    {
        Program = program;
        Location = location;
    }

    /// <inheritdoc />
    public void GetLocation(IShaderProgram shaderProgram)
    {
        shaderProgram.Bind();
        if (Program != 0)
        {
            return;
        }

        Program = shaderProgram.GetId();
        Location = ParamType == ParameterType.Uniform
            ? shaderProgram.GetUniform(Name)
            : shaderProgram.GetAttribute(Name);
    }

    /// <inheritdoc />
    public void SetValue(bool param) =>
        Gl.Uniform1i(
            Location,
            param
                ? 1
                : 0
        );

    /// <inheritdoc />
    public void SetValue(int param) => Gl.Uniform1i(Location, param);

    /// <inheritdoc />
    public void SetValue(float param) => Gl.Uniform1f(Location, param);

    /// <inheritdoc />
    public void SetValue(Vector2 param) => Gl.Uniform2f(Location, param.X, param.Y);

    /// <inheritdoc />
    public void SetValue(Vector3 param) => Gl.Uniform3f(Location, param.X, param.Y, param.Z);

    /// <inheritdoc />
    public void SetValue(Vector4 param) => Gl.Uniform4f(Location, param.X, param.Y, param.Z, param.W);

    /// <inheritdoc />
    public void SetValue(Color param) => Gl.Uniform4f(Location, param.R / 255f, param.G / 255f, param.B / 255f, param.A / 255f);

    /// <inheritdoc />
    public void SetValue(Matrix2 param) => UniformMatrix2fv(Location, param);

    /// <inheritdoc />
    public void SetValue(Matrix3 param) => UniformMatrix3fv(Location, param);

    /// <inheritdoc />
    public void SetValue(Matrix4 param) => UniformMatrix4fv(Location, param);

    /// <inheritdoc />
    public void SetValue(float[] param)
    {
        switch (param.Length)
        {
            case 16 when Type != typeof(Matrix4):
                throw new FormatException($"SetValue({Type}) was given a Matrix4.");
            case 16:
                Gl.UniformMatrix4fv(Location, 1, false, param);
                break;
            case 9 when Type != typeof(Matrix3):
                throw new FormatException($"SetValue({Type}) was given a Matrix3.");
            case 9:
                Gl.UniformMatrix3fv(Location, 1, false, param);
                break;
            case 4 when Type != typeof(Vector4):
                throw new FormatException($"SetValue({Type}) was given a Vector4.");
            case 4:
                Gl.Uniform4f(Location, param[0], param[1], param[2], param[3]);
                break;
            case 3 when Type != typeof(Vector3):
                throw new FormatException($"SetValue({Type}) was given a Vector3.");
            case 3:
                Gl.Uniform3f(Location, param[0], param[1], param[2]);
                break;
            case 2 when Type != typeof(Vector2):
                throw new FormatException($"SetValue({Type}) was given a Vector2.");
            case 2:
                Gl.Uniform2f(Location, param[0], param[1]);
                break;
            case 1 when Type != typeof(float):
                throw new FormatException($"SetValue({Type}) was given a float.");
            case 1:
                Gl.Uniform1f(Location, param[0]);
                break;
            default:
                throw new ArgumentException("param was an unexpected length.", "param");
        }
    }

    /// <summary>
    ///     Set a uniform mat2 in the shaderProgram.
    /// </summary>
    private void UniformMatrix2fv(int location, Matrix2 param)
    {
        _uniformMatrix2[0] = param.M11;
        _uniformMatrix3[1] = param.M12;

        _uniformMatrix3[3] = param.M21;
        _uniformMatrix3[4] = param.M22;

        Gl.UniformMatrix2fv(location, 1, false, _uniformMatrix2);
    }

    /// <summary>
    ///     Set a uniform mat3 in the shaderProgram.
    /// </summary>
    private void UniformMatrix3fv(int location, Matrix3 param)
    {
        _uniformMatrix3[0] = param.M11;
        _uniformMatrix3[1] = param.M12;
        _uniformMatrix3[2] = param.M13;

        _uniformMatrix3[3] = param.M21;
        _uniformMatrix3[4] = param.M22;
        _uniformMatrix3[5] = param.M23;

        _uniformMatrix3[6] = param.M31;
        _uniformMatrix3[7] = param.M32;
        _uniformMatrix3[8] = param.M33;

        Gl.UniformMatrix3fv(location, 1, false, _uniformMatrix3);
    }

    /// <summary>
    ///     Set a uniform mat4 in the shaderProgram.
    /// </summary>
    private void UniformMatrix4fv(int location, Matrix4 param)
    {
        _uniformMatrix4[0] = param.M11;
        _uniformMatrix4[1] = param.M12;
        _uniformMatrix4[2] = param.M13;
        _uniformMatrix4[3] = param.M14;

        _uniformMatrix4[4] = param.M21;
        _uniformMatrix4[5] = param.M22;
        _uniformMatrix4[6] = param.M23;
        _uniformMatrix4[7] = param.M24;

        _uniformMatrix4[8] = param.M31;
        _uniformMatrix4[9] = param.M32;
        _uniformMatrix4[10] = param.M33;
        _uniformMatrix4[11] = param.M34;

        _uniformMatrix4[12] = param.M41;
        _uniformMatrix4[13] = param.M42;
        _uniformMatrix4[14] = param.M43;
        _uniformMatrix4[15] = param.M44;

        Gl.UniformMatrix4fv(location, 1, false, _uniformMatrix4);
    }
}
