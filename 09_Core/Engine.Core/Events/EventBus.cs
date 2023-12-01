namespace Engine.Core.Events;

/// <summary>
///     Implementation for EventSystem
/// </summary>
public static class EventBus
{
    private static readonly Dictionary<Type, IEnumerable<IEventListener>> Subscribers = new();

    /// <summary>
    ///     Subscribe to a event
    /// </summary>
    /// <param name="listener">The listener</param>
    /// <typeparam name="T">The type of the event</typeparam>
    public static void Subscribe<T>(IEventListener<T> listener)
        where T : IEvent
    {
        var type = typeof(T);
        if (!Subscribers.TryGetValue(type, out var value))
        {
            value = new List<IEventListener>();
            Subscribers.Add(type, value);
        }

        var subscribers = value.ToList();
        subscribers.Add(listener);
        Subscribers[type] = subscribers;
    }

    /// <summary>
    ///     Unsubscribe from a event
    /// </summary>
    /// <param name="listener">The listener</param>
    /// <typeparam name="T">The type of the event</typeparam>
    public static void Unsubscribe<T>(IEventListener<T> listener)
        where T : IEvent
    {
        var type = typeof(T);
        if (!Subscribers.TryGetValue(type, out var value))
        {
            return;
        }

        var subscribers = value.ToList();
        subscribers.Remove(listener);
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
            (subscriber as IEventListener<T>)?.ReceiveEvent(data);
        }
    }
}
