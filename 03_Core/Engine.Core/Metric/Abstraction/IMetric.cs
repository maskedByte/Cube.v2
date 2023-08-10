namespace Engine.Core.Metric.Abstraction;

/// <summary>
/// Public interface for state
/// </summary>
public interface IMetric
{
    /// <summary>
    /// Type of the stored data
    /// </summary>
    Type DataType { get; }

    /// <summary>
    /// Get the stored data name
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Get the stored data value
    /// </summary>
    object Data { get; }

    /// <summary>
    /// Reset state
    /// </summary>
    void Reset();
}
