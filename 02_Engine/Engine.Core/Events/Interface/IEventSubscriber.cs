namespace Engine.Core.Events.Interface;

/// <summary>
/// Provides a interface to handle event subscriptions
/// </summary>
public interface IEventSubscriber
{
    /// <summary>
    /// Reacting to an received event
    /// </summary>
    /// <param name="data">Payload data which was send together with the event</param>
    /// <typeparam name="T">Type of the date the event can receive</typeparam>
    void ReceiveEvent<T>(T data);
}
