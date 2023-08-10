namespace Engine.Core.Memory.Pinning;

/// <summary>
/// Base interface for pinned structures
/// </summary>
public interface IPinnedStructure
{
    void Free();
}

/// <summary>
/// Interface for pinned structures
/// </summary>
/// <typeparam name="T">The type of the structure.</typeparam>
public interface IPinnedStructure<T> : IPinnedStructure
{
    IntPtr Address { get; }
    T? Get();
    void Set(T value);
}
