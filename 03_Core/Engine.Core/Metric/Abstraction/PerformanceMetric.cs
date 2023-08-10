namespace Engine.Core.Metric.Abstraction;

/// <summary>
///     Abstract monitor class
/// </summary>
/// <typeparam name="TValueType"></typeparam>
public abstract class PerformanceMetric<TValueType> : IMetric where TValueType : struct
{
    /// <summary>
    ///     Get or set the value for this <see cref="PerformanceMetric{TValueType}" />
    /// </summary>
    public TValueType Value { get; set; }

    object IMetric.Data => Value;

    Type IMetric.DataType => typeof(TValueType);

    /// <inheritdoc />
    public string Name { get; }

    /// <summary>
    ///     Create a new state
    /// </summary>
    /// <param name="name">Name of the <see cref="PerformanceMetric{TValueType}" /></param>
    /// <param name="initial">Initial value of the <see cref="PerformanceMetric{TValueType}" /></param>
    protected PerformanceMetric(string name, TValueType initial = default)
    {
        Name = name;
        Value = initial;

        PerformanceMetricManager.Instance.Add(this);
    }

    /// <inheritdoc />
    public void Reset() => Value = default;

    ~PerformanceMetric()
    {
        PerformanceMetricManager.Instance.Remove(this);
    }
}
