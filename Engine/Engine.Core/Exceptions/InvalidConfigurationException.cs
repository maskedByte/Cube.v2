namespace Engine.Exceptions;

public class InvalidConfigurationException : Exception
{
    public InvalidConfigurationException(string path) :
        base($"Invalid configuration file: {path}")
    {
    }
}
