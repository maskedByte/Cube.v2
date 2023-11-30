namespace Engine.Core.Events;

/// <summary>
///     Base class for a event implementation
/// </summary>
/// <typeparam name="T"></typeparam>
public class Event<T> : IEvent<T>
{
    public Guid Id { get; }
    public T Data { get; }
    public Type DataType => typeof(T);

    /// <summary>
    ///     Default constructor
    /// </summary>
    /// <param name="data">The payload</param>
    protected Event(T data)
    {
        ArgumentNullException.ThrowIfNull(data);

        Id = Guid.NewGuid();
        Data = data;
    }
}
