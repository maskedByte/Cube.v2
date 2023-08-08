using System.Runtime.InteropServices;
using Engine.Exceptions;

namespace Engine.Pinning;

/// <summary>
/// A class that stores the type of a structure and the pinned address of the structure.
/// </summary>
/// <typeparam name="T">The type of the structure.</typeparam>
public sealed class PinnedStructure<T> : IPinnedStructure<T>, IDisposable
{
    private readonly IntPtr _address;
    private bool _disposed;

    /// <summary>
    /// The type of the stored structure.
    /// </summary>
    public Type StructureType { get; }

    /// <summary>
    /// Constructs a new instance of the PinnedStructure class.
    /// </summary>
    public PinnedStructure()
    {
        _disposed = false;
        StructureType = typeof(T);

        Address = Marshal.AllocHGlobal(Marshal.SizeOf<T>());
        if (Address == IntPtr.Zero)
        {
            throw new Exception("Could not allocate memory for the structure.");
        }
    }

    public void Dispose()
    {
        Free();
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// The pinned address of the structure.
    /// </summary>
    public IntPtr Address
    {
        get
        {
            if (_disposed)
            {
                throw new MemoryNotAccessibleException();
            }

            return _address;
        }
        private init { _address = value; }
    }

    /// <summary>
    /// Retrieves the structure from the pinned memory.
    /// </summary>
    /// <returns>The retrieved structure.</returns>
    public T? Get()
    {
        if (_disposed)
        {
            throw new MemoryNotAccessibleException();
        }

        return Marshal.PtrToStructure<T>(Address);
    }

    /// <summary>
    /// Sets the structure in the pinned memory.
    /// </summary>
    /// <param name="value">The structure to set.</param>
    public void Set(T value)
    {
        if (_disposed)
        {
            throw new MemoryNotAccessibleException();
        }

        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        Marshal.StructureToPtr(value, Address, false);
    }

    /// <summary>
    /// Frees the pinned memory.
    /// </summary>
    public void Free()
    {
        if (_disposed)
        {
            return;
        }

        Marshal.FreeHGlobal(Address);
        _disposed = true;
    }

    ~PinnedStructure()
    {
        Dispose();
    }
}
