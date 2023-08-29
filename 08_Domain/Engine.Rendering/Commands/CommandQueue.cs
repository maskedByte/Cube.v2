namespace Engine.Rendering.Commands;

/// <summary>
///     Implementation of <see cref="ICommandQueue" />
/// </summary>
public class CommandQueue : ICommandQueue
{
    private readonly List<ICommand> _commands;
    private int _currentIndex;
    private bool _started;

    public bool IsReady { get; private set; }

    /// <summary>
    ///     Default constructor
    /// </summary>
    public CommandQueue()
    {
        _commands = new List<ICommand>();
        _currentIndex = 0;
        _started = false;
        IsReady = false;
    }

    public void Begin()
    {
        if (_started)
        {
            return;
        }

        _currentIndex = 0;
        _started = true;
        IsReady = false;
        _commands.Clear();
    }

    /// <inheritdoc />
    public void Enqueue(ICommand command) => _commands.Add(command);

    /// <inheritdoc />
    public bool TryDequeue(out ICommand? command)
    {
        command = Dequeue();
        return command != null;
    }

    /// <inheritdoc />
    public ICommand? Dequeue()
    {
        if (_commands.Count <= 0)
        {
            return null;
        }

        var firstCommand = _commands[0];
        _commands.RemoveAt(0);
        _currentIndex++;
        return firstCommand;
    }

    public void End()
    {
        if (!_started)
        {
            return;
        }

        _started = false;
        IsReady = true;
    }

    /// <inheritdoc />
    public void Dispose() => _commands.Clear();
}
