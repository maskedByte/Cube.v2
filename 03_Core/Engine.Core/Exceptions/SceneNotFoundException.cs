using System.Runtime.Serialization;

namespace Engine.Core.Exceptions;

public class SceneNotFoundException : Exception
{
    public SceneNotFoundException()
    {
    }

    public SceneNotFoundException(string? message)
        : base(message)
    {
    }

    public SceneNotFoundException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }

    protected SceneNotFoundException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}
