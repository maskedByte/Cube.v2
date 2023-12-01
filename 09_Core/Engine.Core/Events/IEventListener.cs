namespace Engine.Core.Events;

/// <summary>
///    Provides a interface for a a event listener
/// </summary>
public interface IEventListener
{
}

/// <summary>
///     Provides a interface to handle event listener
/// </summary>
public interface IEventListener<in T> : IEventListener
    where T : IEvent
{
    /// <summary>
    ///     Receive a new event
    /// </summary>
    /// <param name="data">The event data</param>
    void ReceiveEvent(T data);
}
