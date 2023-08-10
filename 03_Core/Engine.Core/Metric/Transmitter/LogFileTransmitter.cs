using Engine.Core.Metric.Abstraction;

namespace Engine.Core.Metric.Transmitter;

/// <summary>
/// This class implements the IMetricsTransmitter interface and provides the specific
/// behavior for transmitting performance metrics to a log file.
/// </summary>
public class LogFileTransmitter : IMetricsTransmitter
{
    /// <inheritdoc />
    public void Transmit()
    {
        using var writer = File.AppendText("performance.log");
        foreach (var metric in PerformanceMetricManager.Instance.GetAll())
        {
            writer.WriteLine($"{metric.Key} - {metric.Value}");
        }
    }
}
