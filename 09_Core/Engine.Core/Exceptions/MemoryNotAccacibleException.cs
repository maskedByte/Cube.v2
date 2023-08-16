namespace Engine.Core.Exceptions;

public class MemoryNotAccessibleException : Exception
{
    /// <summary>
    ///     Create instance of <see cref="Exception" />
    /// </summary>
    public MemoryNotAccessibleException()
        : base("Memory is not accessible")
    {
    }
}
