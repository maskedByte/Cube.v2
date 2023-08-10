using Engine.Core.Metric.Abstraction;

namespace Engine.Core.Metric.Transmitter;

/// <summary>
/// This class implements the IMetricsTransmitter interface and provides the specific
/// behavior for transmitting performance metrics to the console.
/// </summary>
public sealed class ConsoleTransmitter : IMetricsTransmitter
{
    /// <inheritdoc />
    public void Transmit()
    {
        foreach (var metric in PerformanceMetricManager.Instance.GetAll())
        {
            Console.WriteLine($"{metric.Key} - {metric.Value}");
        }
    }
}
