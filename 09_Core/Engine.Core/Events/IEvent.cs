namespace Engine.Core.Events;

/// <summary>
///     Provides a interface for a event
/// </summary>
public interface IEvent
{
    Type DataType { get; }
}

/// <summary>
///     Provides a interface for a event with a payload and a generic type
/// </summary>
/// <typeparam name="T">The type of the payload</typeparam>
public interface IEvent<out T> : IEvent
{
    /// <summary>
    ///     Id of the event
    /// </summary>
    Guid Id { get; }

    /// <summary>
    ///     The payload
    /// </summary>
    T Data { get; }
}
