namespace Engine.Core.Logging;

/// <summary>
///     Interface for log targets
/// </summary>
public interface ILogTarget : IDisposable
{
    /// <summary>
    ///     Logs a message
    /// </summary>
    Task LogMessageAsync(LogEntry logEntry);
}
