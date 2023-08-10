using System.ComponentModel;
using Engine.Core.Driver.Graphics.Shaders;
using Engine.Core.Extensions;
using Engine.Core.Logging;
using Engine.OpenGL.Vendor.OpenGL.Core;

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

namespace Engine.OpenGL.Driver.GraphicsApi.Shaders;

/// <summary>
///     Represents a shader and its compiled status.
/// </summary>
internal sealed class GlShader : IShader
{
    private readonly uint _shaderId;

    private readonly Dictionary<ShaderSourceType, ShaderType> _shaderType = new()
    {
        { ShaderSourceType.Vertex, ShaderType.VertexShader },
        { ShaderSourceType.Fragment, ShaderType.FragmentShader },
        { ShaderSourceType.Geometry, ShaderType.GeometryShader },
        { ShaderSourceType.TessControl, ShaderType.TessControlShader },
        { ShaderSourceType.TessEvaluation, ShaderType.TessEvaluationShader },
        { ShaderSourceType.Compute, ShaderType.ComputeShader }
    };

    /// <inheritdoc />
    public bool Compiled { get; set; }

    /// <inheritdoc />
    public ShaderSourceType Type { get; }

    /// <inheritdoc />
    public string[] Source { get; }

    /// <summary>
    ///     Creates a new shader.
    /// </summary>
    /// <param name="shaderSourceType">The type of shader.</param>
    /// <param name="source">The source code of the shader.</param>
    public GlShader(ShaderSourceType shaderSourceType, string[] source)
    {
        if (!Enum.IsDefined(typeof(ShaderSourceType), shaderSourceType))
        {
            throw new InvalidEnumArgumentException(
                nameof(shaderSourceType),
                (int)shaderSourceType,
                typeof(ShaderSourceType)
            );
        }

        if (source.IsNullOrAllElementsNull())
        {
            throw new ArgumentException("Source cannot be null or whitespace.", nameof(source));
        }

        Type = shaderSourceType;
        Source = source;

        _shaderId = Gl.CreateShader(_shaderType[shaderSourceType]);
        Gl.CheckError($"{nameof(GlShader)}#Gl.CreateShader");

        Gl.ShaderSource(_shaderId, source);
        Gl.CheckError($"{nameof(GlShader)}#Gl.ShaderSource");
    }

    /// <inheritdoc />
    public void Dispose()
    {
        Gl.DeleteShader(_shaderId);
        Gl.CheckError($"{nameof(GlShader)}#Gl.DeleteShader");
    }

    /// <inheritdoc />
    public void Compile(bool force = false)
    {
        if (Compiled && !force)
        {
            return;
        }

        Gl.CompileShader(_shaderId);
        CheckCompileError(_shaderId);
    }

    /// <inheritdoc />
    public uint GetId() => _shaderId;

    private void CheckCompileError(uint shader)
    {
        if (Gl.GetShaderCompileStatus(shader))
        {
            Compiled = true;
            return;
        }

        var message = Gl.GetShaderInfoLog(shader);
        Log.LogMessageAsync($"Failed to compile shader! {message}", LogLevel.Error, this);

        Compiled = false;
    }
}
