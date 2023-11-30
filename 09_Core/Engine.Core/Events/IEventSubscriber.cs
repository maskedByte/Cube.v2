namespace Engine.Core.Events;

/// <summary>
///    Provides a interface for a a event subscriber
/// </summary>
public interface IEventSubscriber
{
}

/// <summary>
///     Provides a interface to handle event subscriptions
/// </summary>
public interface IEventSubscriber<in T> : IEventSubscriber
    where T : IEvent
{
    /// <summary>
    ///     Receive a new event
    /// </summary>
    /// <param name="data">The event data</param>
    void ReceiveEvent(T data);
}
