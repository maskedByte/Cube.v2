namespace Engine.Exceptions;

public class UnknownConfigurationLoaderException : Exception
{
    public UnknownConfigurationLoaderException(string fileExt)
        : base(fileExt)
    {
    }

    public UnknownConfigurationLoaderException(string fileExt, Exception? innerException)
        : base(fileExt, innerException)
    {
    }
}
