using Engine.Core.Events.Interface;

namespace Engine.Core.Events;

/// <summary>
/// Implementation for EventSystem
/// </summary>
public static class EventBus
{
    private static readonly Dictionary<string, List<IEventSubscriber?>> Subscribers =
        new Dictionary<string, List<IEventSubscriber?>>();

    /// <summary>
    /// Register a new <see cref="IEventSubscriber" /> to the Bus
    /// </summary>
    /// <param name="eventName">Name of the event to subscribe to</param>
    /// <param name="subscriber">The <see cref="IEventSubscriber" /> instance</param>
    public static void Subscribe(string eventName, IEventSubscriber subscriber)
    {
        var newEventName = eventName.ToLower();
        if (!Subscribers.ContainsKey(newEventName))
        {
            Subscribers.Add(newEventName, new List<IEventSubscriber?>());
        }

        if (Subscribers.TryGetValue(newEventName, out var subscribers))
        {
            if (subscribers.Contains(subscriber))
            {
                return;
            }
        }

        Subscribers[newEventName].Add(subscriber);
    }

    /// <summary>
    /// unsubscribe from an event
    /// </summary>
    /// <param name="eventName">Name of the event to unsubscribe from</param>
    /// <param name="subscriber">The <see cref="IEventSubscriber" /> instance</param>
    public static void Unsubscribe(string eventName, IEventSubscriber subscriber)
    {
        var eventN = eventName.ToLower();
        if (!Subscribers.ContainsKey(eventN))
        {
            return;
        }

        Subscribers[eventN].Remove(subscriber);
    }

    /// <summary>
    /// Dispatch a new event and set it's payload
    /// </summary>
    /// <param name="eventName">The name of the event to dispatch</param>
    /// <param name="payload"></param>
    /// <typeparam name="T">Type of the payload</typeparam>
    public static void Dispatch<T>(string eventName, T payload)
    {
        var eventN = eventName.ToLower();

        if (!Subscribers.ContainsKey(eventN))
        {
            return;
        }

        foreach (var subscriber in Subscribers[eventN])
        {
            subscriber?.ReceiveEvent(payload);
        }
    }
}
