using System.ComponentModel;

namespace Engine.Core.Exceptions;

/// <summary>
///     Implementation of <see cref="Exception" /> for throw exception if a <see cref="IComponent" /> is required in
///     registration but was not found
/// </summary>
public class MissingComponentException : Exception
{
    /// <summary>
    ///     Create new <see cref="MissingComponentException" />
    /// </summary>
    /// <param name="componentName">Name of the missed component</param>
    public MissingComponentException(string componentName)
        : base(componentName)
    {
    }
}
