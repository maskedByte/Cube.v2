using Engine.Core.Metric.Abstraction;

namespace Engine.Core.Metric.Measures;

/// <summary>
/// <see cref="CountMetric" /> implementation to measure the count of something
/// </summary>
public sealed class CountMetric : PerformanceMetric<int>
{
    /// <summary>
    /// Initialize a new <see cref="CountMetric" />
    /// </summary>
    public CountMetric(string name, int initial = default)
        : base(name, initial)
    {
    }

    /// <summary>
    /// Increment the internal counter
    /// </summary>
    public void Inc()
    {
        Value++;
    }

    /// <summary>
    /// Decrement the internal counter
    /// </summary>
    public void Dec()
    {
        Value--;
    }
}
