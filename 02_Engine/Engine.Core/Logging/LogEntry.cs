namespace Engine.Logging;

/// <summary>
/// Log entry implementation
/// </summary>
public class LogEntry
{
    /// <summary>
    /// The timestamp of the log entry
    /// </summary>
    public DateTimeOffset Timestamp { get; set; }

    /// <summary>
    /// The log level of the entry
    /// </summary>
    public LogLevel Level { get; set; }

    /// <summary>
    /// The message of the entry
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// The source of the entry
    /// </summary>
    public string? Source { get; set; }

    /// <summary>
    /// Basic constructor
    /// </summary>
    /// <param name="timestamp">The timestamp of the log entry</param>
    /// <param name="level">Log level of the entry</param>
    /// <param name="message">Message of the entry</param>
    /// <param name="source">Source of the entry</param>
    public LogEntry(DateTimeOffset timestamp, LogLevel level, string message, string? source)
    {
        Timestamp = timestamp;
        Level = level;
        Message = message;
        Source = source;
    }

    /// <summary>
    /// Returns a formatted log entry
    /// </summary>
    /// <returns>The formatted log entry</returns>
    public string GetFormattedLogEntry()
    {
        return
            $"{Timestamp:yyyy-MM-dd HH:mm:ss.fff} / {Source} [{Level}] - {Message}";
    }
}
