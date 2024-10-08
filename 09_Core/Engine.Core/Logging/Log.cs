﻿using Engine.Core.Logging.Targets;

namespace Engine.Core.Logging;

/// <summary>
///     Log system implementation that allows to log messages to multiple targets.
/// <remarks> Default target is the console. </remarks>
/// </summary>
public static class Log
{
    private static readonly object Lock = new();
    private static readonly List<ILogTarget> Targets = new();

    static Log()
    {
        AddTarget(new ConsoleLogTarget());
    }

    /// <summary>
    ///     Adds a new log target
    /// </summary>
    /// <param name="target">The target to add.</param>
    public static void AddTarget(ILogTarget target)
    {
        lock (Lock)
        {
            Targets.Add(target);
        }
    }

    /// <summary>
    ///     Removes a log target
    /// </summary>
    /// <param name="target">The target to remove.</param>
    public static void RemoveTarget(ILogTarget target)
    {
        lock (Lock)
        {
            Targets.Remove(target);
        }
    }

    /// <summary>
    ///     Logs a message
    /// </summary>
    /// <param name="message">The message to log</param>
    /// <param name="level">The log level</param>
    /// <param name="source">The source of the message</param>
    public static async Task LogMessageAsync<TSource>(string message, LogLevel level, TSource? source)
    {
        var logEntry = new LogEntry(DateTimeOffset.Now, level, message, source?.GetType().Name);
        var logTasks = new List<Task>();

        lock (Lock)
        {
            logTasks.AddRange(Targets.Select(target => target.LogMessageAsync(logEntry)));
        }

        try
        {
            await Task.WhenAll(logTasks);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while logging: {ex}");
        }
    }
}
