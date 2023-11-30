namespace Engine.Core.Events;

/// <summary>
///     Implementation for EventSystem
/// </summary>
public static class EventBus
{
    private static readonly Dictionary<Type, IEnumerable<IEventSubscriber>> Subscribers = new();

    /// <summary>
    ///     Subscribe to a event
    /// </summary>
    /// <param name="subscriber">The subscriber</param>
    /// <typeparam name="T">The type of the event</typeparam>
    public static void Subscribe<T>(IEventSubscriber<T> subscriber)
        where T : IEvent
    {
        var type = typeof(T);
        if (!Subscribers.TryGetValue(type, out var value))
        {
            value = new List<IEventSubscriber>();
            Subscribers.Add(type, value);
        }

        var subscribers = value.ToList();
        subscribers.Add(subscriber);
        Subscribers[type] = subscribers;
    }

    /// <summary>
    ///     Unsubscribe from a event
    /// </summary>
    /// <param name="subscriber">The subscriber</param>
    /// <typeparam name="T">The type of the event</typeparam>
    public static void Unsubscribe<T>(IEventSubscriber<T> subscriber)
        where T : IEvent
    {
        var type = typeof(T);
        if (!Subscribers.TryGetValue(type, out var value))
        {
            return;
        }

        var subscribers = value.ToList();
        subscribers.Remove(subscriber);
        Subscribers[type] = subscribers;
    }

    /// <summary>
    ///     Publish a event
    /// </summary>
    /// <param name="data">The event data</param>
    /// <typeparam name="T">The type of the event</typeparam>
    public static void Publish<T>(T data)
        where T : IEvent
    {
        var type = typeof(T);
        if (!Subscribers.TryGetValue(type, out var subscribers))
        {
            return;
        }

        foreach (var subscriber in subscribers)
        {
            (subscriber as IEventSubscriber<T>)?.ReceiveEvent(data);
        }
    }
}
