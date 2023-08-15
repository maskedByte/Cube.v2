using Engine.Core.Driver.Graphics.Textures;

namespace Engine.Core.Rendering.Commands;

/// <summary>
///     Result of a render command
/// </summary>
public interface ICommandResult : IDisposable
{
    /// <summary>
    ///     Indicates if the command was successful
    /// </summary>
    bool IsSuccess { get; }

    /// <summary>
    ///     The texture that contains the result of the command
    /// </summary>
    ITexture? FramebufferResult { get; }
}
