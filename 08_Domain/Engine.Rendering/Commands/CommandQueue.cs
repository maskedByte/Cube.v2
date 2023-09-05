namespace Engine.Rendering.Commands;

/// <summary>
///     Implementation of <see cref="ICommandQueue" />
/// </summary>
public class CommandQueue : ICommandQueue
{
    private readonly PriorityQueue<ICommand, long> _sortedCommands;
    private int _currentIndex;
    private bool _started;

    public bool IsReady { get; private set; }

    /// <summary>
    ///     Default constructor
    /// </summary>
    public CommandQueue()
    {
        _sortedCommands = new PriorityQueue<ICommand, long>();

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
        _sortedCommands.Clear();
    }

    /// <inheritdoc />
    public void Enqueue(in ICommand command)
    {
        _currentIndex++;
        _sortedCommands.Enqueue(command, GetSortingKey(command));
    }

    /// <inheritdoc />
    public bool TryDequeue(out ICommand? command) => _sortedCommands.TryDequeue(out command, out _);

    /// <inheritdoc />
    public ICommand? Dequeue() => _sortedCommands.Dequeue();

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
    public void Dispose() => _sortedCommands.Clear();

    private long GetSortingKey(in ICommand command) => command.Priority * 1000 + _currentIndex;
}
