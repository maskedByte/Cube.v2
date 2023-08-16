using Engine.Core.Driver.Graphics.Shaders;
using Engine.Core.Math.Base;
using Engine.Core.Math.Matrices;
using Engine.Core.Math.Vectors;

namespace Engine.Core.Driver.Graphics.Buffers;

/// <summary>
///     <see cref="IUniformBuffer" /> interface
/// </summary>
public interface IUniformBuffer : IBuffer
{
    /// <summary>
    ///     Attach the <see cref="IUniformBuffer" /> to an existing <see cref="shaderProgram" />
    /// </summary>
    /// <remarks>Checks internally if the buffer was already bound to this shader</remarks>
    /// <param name="shaderProgram"><see cref="IUniformBuffer" /> to attach the <see cref="IShaderProgram" /> to</param>
    void Attach(IShaderProgram shaderProgram);

    /// <summary>
    ///     Set <see cref="IUniformBuffer" /> buffer date for <paramref name="name" /> of type <see cref="float" />
    /// </summary>
    void SetUniformData(string name, float value);

    /// <summary>
    ///     Set <see cref="IUniformBuffer" /> buffer date for <paramref name="name" /> of type <see cref="Vector2" />
    /// </summary>
    void SetUniformData(string name, Vector2 value);

    /// <summary>
    ///     Set <see cref="IUniformBuffer" /> buffer date for <paramref name="name" /> of type <see cref="Vector3" />
    /// </summary>
    void SetUniformData(string name, Vector3 value);

    /// <summary>
    ///     Set <see cref="IUniformBuffer" /> buffer date for <paramref name="name" /> of type <see cref="Vector4" />
    /// </summary>
    void SetUniformData(string name, Vector4 value);

    /// <summary>
    ///     Set <see cref="IUniformBuffer" /> buffer date for <paramref name="name" /> of type <see cref="Color" />
    /// </summary>
    void SetUniformData(string name, Color value);

    /// <summary>
    ///     Set <see cref="IUniformBuffer" /> buffer date for <paramref name="name" /> of type <see cref="Matrix2" />
    /// </summary>
    void SetUniformData(string name, Matrix2 value);

    /// <summary>
    ///     Set <see cref="IUniformBuffer" /> buffer date for <paramref name="name" /> of type <see cref="Matrix3" />
    /// </summary>
    void SetUniformData(string name, Matrix3 value);

    /// <summary>
    ///     Set <see cref="IUniformBuffer" /> buffer date for <paramref name="name" /> of type <see cref="Matrix4" />
    /// </summary>
    void SetUniformData(string name, Matrix4 value);
}
