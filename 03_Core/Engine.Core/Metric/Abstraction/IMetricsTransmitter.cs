namespace Engine.Core.Metric.Abstraction;

/// <summary>
/// This interface defines a common set of methods for transmitting performance metrics to an external destination.
/// </summary>
public interface IMetricsTransmitter
{
    /// <summary>
    /// Transmits the specified performance metrics to the external destination.
    /// </summary>
    void Transmit();
}
