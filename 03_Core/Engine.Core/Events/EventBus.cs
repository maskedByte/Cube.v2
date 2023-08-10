namespace Engine.Core.Events;

/// <summary>
///     Implementation for EventSystem
/// </summary>
public static class EventBus
{
    private static readonly Dictionary<string, List<IEventSubscriber?>> Subscribers = new();

    /// <summary>
    ///     Register a new <see cref="IEventSubscriber" /> to the Bus
    /// </summary>
    /// <param name="eventName">Name of the event to subscribe to</param>
    /// <param name="subscriber">The <see cref="IEventSubscriber" /> instance</param>
    public static void Subscribe(string eventName, IEventSubscriber subscriber)
    {
        var loweredEventName = eventName.ToLower();
        if (!Subscribers.ContainsKey(loweredEventName))
        {
            Subscribers.Add(loweredEventName, new List<IEventSubscriber?>());
        }

        if (!Subscribers[loweredEventName].Contains(subscriber))
        {
            Subscribers[loweredEventName].Add(subscriber);
        }
    }

    /// <summary>
    ///     unsubscribe from an event
    /// </summary>
    /// <param name="eventName">Name of the event to unsubscribe from</param>
    /// <param name="subscriber">The <see cref="IEventSubscriber" /> instance</param>
    public static void Unsubscribe(string eventName, IEventSubscriber subscriber)
    {
        var loweredEventName = eventName.ToLower();
        if (Subscribers.TryGetValue(loweredEventName, out var eventSubscribers))
        {
            eventSubscribers.Remove(subscriber);
        }
    }

    /// <summary>
    ///     Dispatch a new event and set it's payload
    /// </summary>
    /// <param name="eventName">The name of the event to dispatch</param>
    /// <param name="payload"></param>
    /// <typeparam name="T">Type of the payload</typeparam>
    public static void Dispatch<T>(string eventName, T payload)
    {
        var loweredEventName = eventName.ToLower();

        if (!Subscribers.TryGetValue(loweredEventName, out var eventSubscribers))
        {
            return;
        }

        foreach (var subscriber in eventSubscribers)
        {
            subscriber?.ReceiveEvent(payload);
        }
    }
}
