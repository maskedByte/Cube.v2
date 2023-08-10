namespace Engine.Core.Logging.Targets;

/// <summary>
///     Log target for logging to the console
/// </summary>
public class ConsoleLogTarget : ILogTarget
{
    public async Task LogMessageAsync(LogEntry logEntry) => await Console.Out.WriteLineAsync(logEntry.GetFormattedLogEntry());

    public void Dispose()
    {
    }
}
