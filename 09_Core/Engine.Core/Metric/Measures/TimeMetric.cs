using System.Diagnostics;
using Engine.Core.Metric.Abstraction;

namespace Engine.Core.Metric.Measures;

/// <summary>
///     <see cref="TimeMetric" /> implementation to measure some timings
/// </summary>
public sealed class TimeMetric : PerformanceMetric<float>
{
    private readonly Stopwatch _stopWatch;

    /// <summary>
    ///     Initialize a new <see cref="TimeMetric" />
    /// </summary>
    public TimeMetric(string name, float initial = default)
        : base(name, initial)
    {
        _stopWatch = new Stopwatch();
    }

    /// <summary>
    ///     Start the measurement
    /// </summary>
    public void Start() => _stopWatch.Restart();

    /// <summary>
    ///     Calculate the time between <see cref="Start" /> and now to get the elapsed time
    /// </summary>
    public void Measure()
    {
        Value = _stopWatch.ElapsedMilliseconds;
        Start();
    }
}
