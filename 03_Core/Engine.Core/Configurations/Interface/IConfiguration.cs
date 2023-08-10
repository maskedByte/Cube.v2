using Engine.Core.Math.Base;
using Engine.Core.Math.Matrices;
using Engine.Core.Math.Vectors;

namespace Engine.Core.Configurations.Interface;

/// <summary>
/// <see cref="IConfiguration" /> interface
/// </summary>
public interface IConfiguration
{
    /// <summary>
    /// Add source to load configuration information from
    /// </summary>
    void AddConfig(IDictionary<string, string> source);

    /// <summary>
    /// Add source to load configuration information from
    /// </summary>
    void AddConfig(string key, string value);

    /// <summary>
    /// Add source to load configuration information from.
    /// <remarks>Build is required after adding another source!</remarks>
    /// </summary>
    void AddConfigSource(string file);

    /// <summary>
    /// Generate config
    /// </summary>
    /// <typeparam name="TLoader"></typeparam>
    /// <returns>
    ///     <see cref="ReadOnlySpan{T}" />
    /// </returns>
    ReadOnlySpan<char> GenerateConfiguration<TLoader>() where TLoader : IConfigurationBuilder;

    /// <summary>
    /// Returns value of given key if found. if not return default value
    /// </summary>
    /// <param name="key">Name of the configuration</param>
    /// <param name="defaultValue">Default value if value was not found</param>
    string Get(string key, string defaultValue);

    /// <summary>
    /// Returns value of given key if found. if not return default value
    /// </summary>
    /// <param name="key">Name of the configuration</param>
    /// <param name="defaultValue">Default value if value was not found</param>
    int Get(string key, int defaultValue);

    /// <summary>
    /// Returns value of given key if found. if not return default value
    /// </summary>
    /// <param name="key">Name of the configuration</param>
    /// <param name="defaultValue">Default value if value was not found</param>
    bool Get(string key, bool defaultValue);

    /// <summary>
    /// Returns value of given key if found. if not return default value
    /// </summary>
    /// <param name="key">Name of the configuration</param>
    /// <param name="defaultValue">Default value if value was not found</param>
    float Get(string key, float defaultValue);

    /// <summary>
    /// Returns value of given key if found. if not return default value
    /// </summary>
    /// <param name="key">Name of the configuration</param>
    /// <param name="defaultValue">Default value if value was not found</param>
    double Get(string key, double defaultValue);

    /// <summary>
    /// Returns value of given key if found. if not return default value
    /// </summary>
    /// <param name="key">Name of the configuration</param>
    /// <param name="defaultValue">Default value if value was not found</param>
    Vector2 Get(string key, Vector2 defaultValue);

    /// <summary>
    /// Returns value of given key if found. if not return default value
    /// </summary>
    /// <param name="key">Name of the configuration</param>
    /// <param name="defaultValue">Default value if value was not found</param>
    Vector3 Get(string key, Vector3 defaultValue);

    /// <summary>
    /// Returns value of given key if found. if not return default value
    /// </summary>
    /// <param name="key">Name of the configuration</param>
    /// <param name="defaultValue">Default value if value was not found</param>
    Vector4 Get(string key, Vector4 defaultValue);

    /// <summary>
    /// Returns value of given key if found. if not return default value
    /// </summary>
    /// <param name="key">Name of the configuration</param>
    /// <param name="defaultValue">Default value if value was not found</param>
    Matrix2 Get(string key, Matrix2 defaultValue);

    /// <summary>
    /// Returns value of given key if found. if not return default value
    /// </summary>
    /// <param name="key">Name of the configuration</param>
    /// <param name="defaultValue">Default value if value was not found</param>
    Matrix3 Get(string key, Matrix3 defaultValue);

    /// <summary>
    /// Returns value of given key if found. if not return default value
    /// </summary>
    /// <param name="key">Name of the configuration</param>
    /// <param name="defaultValue">Default value if value was not found</param>
    Matrix4 Get(string key, Matrix4 defaultValue);

    /// <summary>
    /// Returns value of given key if found. if not return default value
    /// </summary>
    /// <param name="key">Name of the configuration</param>
    /// <param name="defaultValue">Default value if value was not found</param>
    Color Get(string key, Color defaultValue);

    /// <summary>
    /// Add or set a given key inside the application configuration
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    void Set(string key, string value);

    /// <summary>
    /// Add or set a given key inside the application configuration
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    void Set(string key, int value);

    /// <summary>
    /// Add or set a given key inside the application configuration
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    void Set(string key, bool value);

    /// <summary>
    /// Add or set a given key inside the application configuration
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    void Set(string key, float value);

    /// <summary>
    /// Add or set a given key inside the application configuration
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    void Set(string key, double value);

    /// <summary>
    /// Add or set a given key inside the application configuration
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    void Set(string key, Vector2 value);

    /// <summary>
    /// Add or set a given key inside the application configuration
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    void Set(string key, Vector3 value);

    /// <summary>
    /// Add or set a given key inside the application configuration
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    void Set(string key, Vector4 value);

    /// <summary>
    /// Add or set a given key inside the application configuration
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    void Set(string key, Matrix2 value);

    /// <summary>
    /// Add or set a given key inside the application configuration
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    void Set(string key, Matrix3 value);

    /// <summary>
    /// Add or set a given key inside the application configuration
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    void Set(string key, Matrix4 value);

    /// <summary>
    /// Add or set a given key inside the application configuration
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    void Set(string key, Color value);
}
