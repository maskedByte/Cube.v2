namespace Engine.Configuration.Interface;

/// <summary>
/// <see cref="IConfigurationBuilder" /> interface
/// </summary>
public interface IConfigurationBuilder
{
    /// <summary>
    /// Get the known extension for this loader
    /// </summary>
    public string Extension { get; }

    /// <summary>
    /// Load specific configuration file
    /// </summary>
    /// <param name="path">Path to load config file</param>
    /// <returns><see cref="Dictionary{TKey,TValue}" /> with configuration information</returns>
    IDictionary<string, string> Load(string path);

    /// <summary>
    /// Build the actual configuration
    /// </summary>
    /// <param name="configuration"><see cref="Dictionary{TKey,TValue}" /> with configuration information</param>
    /// <returns>
    ///     <see cref="ReadOnlySpan{T}" />
    /// </returns>
    ReadOnlySpan<char> Build(IDictionary<string, string> configuration);
}
