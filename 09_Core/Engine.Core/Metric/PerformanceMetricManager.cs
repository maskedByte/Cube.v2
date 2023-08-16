using System.Collections;
using System.Collections.Immutable;
using Engine.Core.Metric.Abstraction;
using Newtonsoft.Json;

namespace Engine.Core.Metric;

/// <summary>
///     Holds all states that were generated
/// </summary>
public sealed class PerformanceMetricManager : IEnumerable<IMetric>
{
    private readonly List<IMetric> _internalList;

    public static PerformanceMetricManager Instance { get; } = new();

    /// <summary>
    ///     Initialize the new instance of <see cref="PerformanceMetricManager" />
    /// </summary>
    public PerformanceMetricManager()
    {
        _internalList = new List<IMetric>();
    }

    /// <summary>
    ///     Get the enumerator of the list
    /// </summary>
    public IEnumerator<IMetric> GetEnumerator() => _internalList.GetEnumerator();

    /// <summary>
    ///     Get the enumerator of the list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    /// <summary>
    ///     Get a dictionary of all
    /// </summary>
    public IImmutableDictionary<string, string?> GetAll() => this.ToImmutableDictionary(x => x.Name, y => y.Data.ToString());

    /// <summary>
    ///     Convert all metrics into json object
    /// </summary>
    public string ToJson() => JsonConvert.SerializeObject(GetAll());

    public void Add(IMetric value) => _internalList.Add(value);

    /// <summary>
    ///     Removes a entry from the
    /// </summary>
    /// <param name="value"></param>
    public void Remove(IMetric value) => _internalList.Remove(value);

    /// <summary>
    ///     Reset all states to default values
    /// </summary>
    public void Reset()
    {
        foreach (var state in this)
        {
            state.Reset();
        }
    }
}
