using System.Text;
using Engine.Core.Driver.Api.Shaders;
using Engine.Core.Logging;
using Engine.Core.Math.Matrices;
using Engine.Core.Math.Vectors;
using Engine.OpenGL.Vendor.OpenGL.Core;

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

namespace Engine.OpenGL.Driver.GraphicsApi.Shaders;

/// <summary>
/// Implementation of <see cref="IShaderProgram" />
/// </summary>
internal sealed class GlShaderProgram : IShaderProgram
{
    private readonly Dictionary<string, IShaderParameter> _shaderParams;
    private readonly uint _shaderProgramId;
    private readonly Dictionary<ShaderSourceType, IShader> _shaders;
    private ShaderProgramState _programState;

    /// <summary>
    /// Create new instance of Shader
    /// </summary>
    public GlShaderProgram()
    {
        _programState = ShaderProgramState.New;
        _shaderParams = new Dictionary<string, IShaderParameter>();
        _shaders = new Dictionary<ShaderSourceType, IShader>();
        _shaderProgramId = Gl.CreateProgram();
    }

    /// <inheritdoc />
    public IShaderParameter this[string name]
    {
        get { return _shaderParams[name]; }
    }

    /// <inheritdoc />
    public uint GetId()
    {
        return _shaderProgramId;
    }

    /// <inheritdoc />
    public void AddShader(IShader shader)
    {
        ArgumentNullException.ThrowIfNull(shader);

        if (_shaders.TryGetValue(shader.Type, out _))
        {
            // Hot reload shader if program is ShaderProgramState is compiled
            _programState = ShaderProgramState.Reload;
            throw new NotImplementedException();
        }
        else
        {
            _shaders.Add(shader.Type, shader);
            _programState = ShaderProgramState.New;
        }
    }

    /// <inheritdoc />
    public ShaderProgramState GetProgramState()
    {
        return _programState;
    }

    /// <inheritdoc />
    public void Compile()
    {
        if (_programState == ShaderProgramState.Compiled)
        {
            return;
        }

        foreach (var t in _shaders)
        {
            t.Value.Compile();
        }

        if (!_shaders.Any())
        {
            Log.LogMessageAsync("No shaders compiled !", LogLevel.Warning, this);
            _programState = ShaderProgramState.Failed;
            return;
        }

        foreach (var t in _shaders)
        {
            Gl.AttachShader(_shaderProgramId, t.Value.GetId());
        }

        Gl.LinkProgram(_shaderProgramId);

        if (!Gl.GetProgramLinkStatus(_shaderProgramId))
        {
            var message = Gl.GetProgramInfoLog(_shaderProgramId);
            Console.WriteLine("Failed to link shader program! \n");
            Console.WriteLine($">> {message}");

            _programState = ShaderProgramState.Failed;
        }

        // Shaders are now linked in the program we don't need them anymore
        foreach (var t in _shaders)
        {
            t.Value.Dispose();
        }

        _programState = ShaderProgramState.Compiled;
        GetParams();
    }

    /// <inheritdoc />
    public void Bind()
    {
        if (Gl.CurrentProgram == _shaderProgramId)
        {
            return;
        }

        switch (_programState)
        {
            case ShaderProgramState.Failed:
                return;

            case ShaderProgramState.New:
                _programState = ShaderProgramState.Compiled;
                Compile();
                break;

            case ShaderProgramState.Compiled:
                Gl.UseProgram(_shaderProgramId);
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    /// <inheritdoc />
    public void Unbind()
    {
        if (_programState == ShaderProgramState.Compiled)
        {
            Gl.UseProgram(0);
        }
    }

    /// <inheritdoc />
    public int GetUniform(string name)
    {
        Bind();
        return Gl.GetUniformLocation(_shaderProgramId, name);
    }

    /// <inheritdoc />
    public int GetAttribute(string name)
    {
        Bind();
        return Gl.GetAttribLocation(_shaderProgramId, name);
    }

    /// <inheritdoc />
    public void Dispose()
    {
        if (_shaderProgramId == 0)
        {
            return;
        }

        // Make sure this program isn't being used
        if (Gl.CurrentProgram == _shaderProgramId)
        {
            Gl.UseProgram(0);
        }

        foreach (var shader in _shaders)
        {
            Gl.DetachShader(_shaderProgramId, shader.Value.GetId());
        }

        Gl.DeleteProgram(_shaderProgramId);
    }

    private void GetParams()
    {
        var resources = new int[1];
        var actualLength = new int[1];
        var arraySize = new int[1];

        Gl.GetProgramiv(_shaderProgramId, ProgramParameter.ActiveAttributes, resources);

        for (var i = 0; i < resources[0]; i++)
        {
            var type = new ActiveAttribType[1];
            var sb = new StringBuilder(256);
            Gl.GetActiveAttrib(_shaderProgramId, i, 256, actualLength, arraySize, type, sb);

            if (!_shaderParams.ContainsKey(sb.ToString()))
            {
                var param = new GlShaderParameter(TypeFromAttributeType(type[0]), ParameterType.Attribute,
                    sb.ToString());
                _shaderParams.Add(param.Name, param);
                param.GetLocation(this);
            }
        }

        Gl.GetProgramiv(_shaderProgramId, ProgramParameter.ActiveUniforms, resources);

        for (var i = 0; i < resources[0]; i++)
        {
            var type = new ActiveUniformType[1];
            var sb = new StringBuilder(256);
            Gl.GetActiveUniform(_shaderProgramId, (uint)i, 256, actualLength, arraySize, type, sb);

            if (!_shaderParams.ContainsKey(sb.ToString()))
            {
                var param = new GlShaderParameter(TypeFromUniformType(type[0]), ParameterType.Uniform,
                    sb.ToString());
                _shaderParams.Add(param.Name, param);
                param.GetLocation(this);
            }
        }
    }

    private Type TypeFromAttributeType(ActiveAttribType type)
    {
        switch (type)
        {
            case ActiveAttribType.Float: return typeof(float);
            case ActiveAttribType.FloatMat2: return typeof(float[]);
            case ActiveAttribType.FloatMat3: return typeof(Matrix3);
            case ActiveAttribType.FloatMat4: return typeof(Matrix4);
            case ActiveAttribType.FloatVec2: return typeof(Vector2);
            case ActiveAttribType.FloatVec3: return typeof(Vector3);
            case ActiveAttribType.FloatVec4: return typeof(Vector4);
            default: return typeof(object);
        }
    }

    private Type TypeFromUniformType(ActiveUniformType type)
    {
        switch (type)
        {
            case ActiveUniformType.Int: return typeof(int);
            case ActiveUniformType.Float: return typeof(float);
            case ActiveUniformType.FloatVec2: return typeof(Vector2);
            case ActiveUniformType.FloatVec3: return typeof(Vector3);
            case ActiveUniformType.FloatVec4: return typeof(Vector4);
            case ActiveUniformType.IntVec2: return typeof(int[]);
            case ActiveUniformType.IntVec3: return typeof(int[]);
            case ActiveUniformType.IntVec4: return typeof(int[]);
            case ActiveUniformType.Bool: return typeof(bool);
            case ActiveUniformType.BoolVec2: return typeof(bool[]);
            case ActiveUniformType.BoolVec3: return typeof(bool[]);
            case ActiveUniformType.BoolVec4: return typeof(bool[]);
            case ActiveUniformType.FloatMat2: return typeof(float[]);
            case ActiveUniformType.FloatMat3: return typeof(Matrix3);
            case ActiveUniformType.FloatMat4: return typeof(Matrix4);
            case ActiveUniformType.Sampler1D:
            case ActiveUniformType.Sampler2D:
            case ActiveUniformType.Sampler3D:
            case ActiveUniformType.SamplerCube:
            case ActiveUniformType.Sampler1DShadow:
            case ActiveUniformType.Sampler2DShadow:
            case ActiveUniformType.Sampler2DRect:
            case ActiveUniformType.Sampler2DRectShadow: return typeof(int);
            case ActiveUniformType.FloatMat2x3:
            case ActiveUniformType.FloatMat2x4:
            case ActiveUniformType.FloatMat3x2:
            case ActiveUniformType.FloatMat3x4:
            case ActiveUniformType.FloatMat4x2:
            case ActiveUniformType.FloatMat4x3: return typeof(float[]);
            case ActiveUniformType.Sampler1DArray:
            case ActiveUniformType.Sampler2DArray:
            case ActiveUniformType.SamplerBuffer:
            case ActiveUniformType.Sampler1DArrayShadow:
            case ActiveUniformType.Sampler2DArrayShadow:
            case ActiveUniformType.SamplerCubeShadow: return typeof(int);
            case ActiveUniformType.UnsignedIntVec2: return typeof(uint[]);
            case ActiveUniformType.UnsignedIntVec3: return typeof(uint[]);
            case ActiveUniformType.UnsignedIntVec4: return typeof(uint[]);
            case ActiveUniformType.IntSampler1D:
            case ActiveUniformType.IntSampler2D:
            case ActiveUniformType.IntSampler3D:
            case ActiveUniformType.IntSamplerCube:
            case ActiveUniformType.IntSampler2DRect:
            case ActiveUniformType.IntSampler1DArray:
            case ActiveUniformType.IntSampler2DArray:
            case ActiveUniformType.IntSamplerBuffer: return typeof(int);
            case ActiveUniformType.UnsignedIntSampler1D:
            case ActiveUniformType.UnsignedIntSampler2D:
            case ActiveUniformType.UnsignedIntSampler3D:
            case ActiveUniformType.UnsignedIntSamplerCube:
            case ActiveUniformType.UnsignedIntSampler2DRect:
            case ActiveUniformType.UnsignedIntSampler1DArray:
            case ActiveUniformType.UnsignedIntSampler2DArray:
            case ActiveUniformType.UnsignedIntSamplerBuffer: return typeof(uint);
            case ActiveUniformType.Sampler2DMultisample: return typeof(int);
            case ActiveUniformType.IntSampler2DMultisample: return typeof(int);
            case ActiveUniformType.UnsignedIntSampler2DMultisample: return typeof(uint);
            case ActiveUniformType.Sampler2DMultisampleArray: return typeof(int);
            case ActiveUniformType.IntSampler2DMultisampleArray: return typeof(int);
            case ActiveUniformType.UnsignedIntSampler2DMultisampleArray: return typeof(uint);
            default: return typeof(object);
        }
    }
}
