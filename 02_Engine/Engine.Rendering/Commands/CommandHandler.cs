using Engine.Core.Driver;
using Engine.Core.Rendering.Commands;

namespace Engine.Rendering.Commands;

/// <summary>
///     Implementation of <see cref="ICommandHandler" /> to handle render commands
/// </summary>
public class RenderCommandHandler : ICommandHandler
{
    private readonly IContext _context;

    public RenderCommandHandler(IContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <inheritdoc />
    public bool CanHandle(ICommand command) =>
        command.Type
            is CommandType.DefaultRenderCommand
            or CommandType.DebugRenderCommand;

    /// <inheritdoc />
    public Task<ICommandResult> HandleAsync(ICommand command)
    {
        if (command is not RenderCommand renderCommand)
        {
            throw new ArgumentException(
                $"RenderCommand must be of type {nameof(RenderCommand)}",
                nameof(command)
            );
        }

        return renderCommand.Type switch
        {
            CommandType.DefaultRenderCommand => HandleDefaultRenderCommandAsync(renderCommand),
            CommandType.DebugRenderCommand   => HandleWireframeRenderCommandAsync(renderCommand),
            _                                => throw new ArgumentOutOfRangeException()
        };
    }

    private Task<ICommandResult> HandleWireframeRenderCommandAsync(RenderCommand renderCommand) => throw new NotImplementedException();

    private Task<ICommandResult> HandleDefaultRenderCommandAsync(RenderCommand renderCommand) => throw new NotImplementedException();

    public void Dispose()
    {
    }
}
