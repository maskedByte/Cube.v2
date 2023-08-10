namespace Engine.Core.Memory.Pinning;

/// <summary>
///     A class that manages pinned structures.
/// </summary>
public class PinnedStructures : IDisposable
{
    private readonly Dictionary<Type, IPinnedStructure> _pinnedStructures;

    /// <summary>
    ///     Initializes a new instance of the PinnedStructures class.
    /// </summary>
    public PinnedStructures()
    {
        _pinnedStructures = new Dictionary<Type, IPinnedStructure>();
    }

    /// <summary>
    ///     Disposes the PinnedStructures instance.
    /// </summary>
    public void Dispose()
    {
        foreach (var kvp in _pinnedStructures)
        {
            kvp.Value.Free();
            _pinnedStructures.Remove(kvp.Key);
        }
    }

    /// <summary>
    ///     Adds a new pinned structure of the specified type.
    /// </summary>
    /// <typeparam name="T">The type of the structure to add.</typeparam>
    public void Add<T>() => _pinnedStructures.Add(typeof(T), new PinnedStructure<T>());

    /// <summary>
    ///     Removes the pinned structure of the specified type.
    /// </summary>
    /// <typeparam name="T">The type of the structure to remove.</typeparam>
    public void Remove<T>()
    {
        _pinnedStructures.TryGetValue(typeof(T), out var structure);
        if (structure != null)
        {
            structure.Free();
            _pinnedStructures.Remove(typeof(T));
        }
    }

    /// <summary>
    ///     Retrieves the pinned structure of the specified type.
    /// </summary>
    /// <typeparam name="T">The type of the structure to retrieve.</typeparam>
    /// <returns>The pinned structure of the specified type.</returns>
    public IPinnedStructure<T> Get<T>() => (IPinnedStructure<T>)_pinnedStructures[typeof(T)];

    /// <summary>
    ///     Frees all pinned structures.
    /// </summary>
    public void Free()
    {
        foreach (var kvp in _pinnedStructures)
        {
            kvp.Value.Free();
            _pinnedStructures.Remove(kvp.Key);
        }
    }
}
