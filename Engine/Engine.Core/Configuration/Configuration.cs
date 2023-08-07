using System.Globalization;
using Engine.Configuration.Interface;
using Engine.Configuration.Loader;
using Engine.Exceptions;
using Engine.Extensions;
using Engine.Math.Core;
using Engine.Math.Matrix;
using Engine.Math.Vector;

#pragma warning disable CS8604

namespace Engine.Configuration;

/// <summary>
/// Implementation for <see cref="IConfiguration" /> to provide application wide configurations
/// <remarks>it can load *.ini, *.json, *.xml, *.yml</remarks>
/// </summary>
public sealed class Configuration : IConfiguration
{
    private readonly List<IConfigurationBuilder> _builder;
    private readonly Dictionary<string, string> _configurations;

    /// <summary>
    /// Singleton instance of <see cref="Configuration" />
    /// </summary>
    public static Configuration Instance { get; } = new Configuration();

    static Configuration()
    {
    }

    private Configuration()
    {
        _configurations = new Dictionary<string, string>();
        _builder = new List<IConfigurationBuilder>
        {
            new IniBuilder(), new XmlBuilder(), new JsonBuilder(), new YamlBuilder()
        };
    }

    /// <inheritdoc />
    public void AddConfig(IDictionary<string, string> source)
    {
        foreach (var (key, value) in source.ToList())
        {
            _configurations.Remove(key);
            _configurations.TryAdd(key.Trim(), value);
        }
    }

    /// <inheritdoc />
    public void AddConfig(string key, string value)
    {
        _configurations.Remove(key);
        _configurations.TryAdd(key, value);
    }

    /// <inheritdoc />
    public void AddConfigSource(string file)
    {
        var fileExt = Path.GetExtension(file)[1..];
        var loader = _builder.FirstOrDefault(x => x.Extension.Contains(fileExt));

        if (loader == null)
        {
            throw new UnknownConfigurationLoaderException(fileExt);
        }

        AddConfig(loader.Load(file));
    }

    /// <inheritdoc />
    public ReadOnlySpan<char> GenerateConfiguration<TBuilder>() where TBuilder : IConfigurationBuilder
    {
        var result = "".AsSpan();
        var builder = GetBuilder(typeof(TBuilder));
        if (builder != null)
        {
            result = builder.Build(_configurations);
        }

        return result;
    }

    public IConfigurationBuilder? GetBuilder(Type builderType)
    {
        return _builder.FirstOrDefault(builder => builderType == builder.GetType());
    }

    #region Getter

    /// <inheritdoc />
    public string Get(string key, string defaultValue)
    {
        _configurations.TryGetValue(key, out var value);
        if (string.IsNullOrWhiteSpace(value))
        {
            Set(key, defaultValue);
            return defaultValue;
        }

        return value;
    }

    /// <inheritdoc />
    public int Get(string key, int defaultValue)
    {
        _configurations.TryGetValue(key, out var value);

        if (string.IsNullOrWhiteSpace(value))
        {
            Set(key, defaultValue);
            return defaultValue;
        }

        return int.Parse(value);
    }

    /// <inheritdoc />
    public bool Get(string key, bool defaultValue)
    {
        _configurations.TryGetValue(key, out var value);

        if (string.IsNullOrWhiteSpace(value))
        {
            Set(key, defaultValue);
            return defaultValue;
        }

        return bool.Parse(value);
    }

    /// <inheritdoc />
    public float Get(string key, float defaultValue)
    {
        _configurations.TryGetValue(key, out var value);

        if (string.IsNullOrWhiteSpace(value))
        {
            Set(key, defaultValue);
            return defaultValue;
        }

        return float.Parse(value, CultureInfo.InvariantCulture);
    }

    /// <inheritdoc />
    public double Get(string key, double defaultValue = default)
    {
        _configurations.TryGetValue(key, out var value);

        if (string.IsNullOrWhiteSpace(value))
        {
            Set(key, defaultValue);
            return defaultValue;
        }

        return double.Parse(value, CultureInfo.InvariantCulture);
    }

    /// <inheritdoc />
    public Vector2 Get(string key, Vector2 defaultValue)
    {
        _configurations.TryGetValue(key, out var value);

        if (string.IsNullOrWhiteSpace(value))
        {
            Set(key, defaultValue);
            return defaultValue;
        }

        return value.ToVector2();
    }

    /// <inheritdoc />
    public Vector3 Get(string key, Vector3 defaultValue)
    {
        _configurations.TryGetValue(key, out var value);
        if (string.IsNullOrWhiteSpace(value))
        {
            Set(key, defaultValue);
            return defaultValue;
        }

        return value.ToVector3();
    }

    /// <inheritdoc />
    public Vector4 Get(string key, Vector4 defaultValue)
    {
        _configurations.TryGetValue(key, out var value);
        if (string.IsNullOrWhiteSpace(value))
        {
            Set(key, defaultValue);
            return defaultValue;
        }

        return value.ToVector4();
    }

    /// <inheritdoc />
    public Matrix2 Get(string key, Matrix2 defaultValue)
    {
        _configurations.TryGetValue(key, out var value);
        if (string.IsNullOrWhiteSpace(value))
        {
            Set(key, defaultValue);
            return defaultValue;
        }

        return value.ToMatrix2();
    }

    /// <inheritdoc />
    public Matrix3 Get(string key, Matrix3 defaultValue)
    {
        _configurations.TryGetValue(key, out var value);
        if (string.IsNullOrWhiteSpace(value))
        {
            Set(key, defaultValue);
            return defaultValue;
        }

        return value.ToMatrix3();
    }

    /// <inheritdoc />
    public Matrix4 Get(string key, Matrix4 defaultValue)
    {
        _configurations.TryGetValue(key, out var value);
        if (string.IsNullOrWhiteSpace(value))
        {
            Set(key, defaultValue);
            return defaultValue;
        }

        return value.ToMatrix4();
    }

    /// <inheritdoc />
    public Color Get(string key, Color defaultValue)
    {
        _configurations.TryGetValue(key, out var value);
        if (string.IsNullOrWhiteSpace(value))
        {
            Set(key, defaultValue);
            return defaultValue;
        }

        return Color.Parse(value);
    }

    #endregion

    #region Setter

    /// <inheritdoc />
    public void Set(string key, string value)
    {
        _configurations.Remove(key);
        _configurations.Add(key, value);
    }

    /// <inheritdoc />
    public void Set(string key, int value)
    {
        _configurations.Remove(key);
        _configurations.Add(key, value.ToString());
    }

    /// <inheritdoc />
    public void Set(string key, bool value)
    {
        _configurations.Remove(key);
        _configurations.Add(key, value.ToString());
    }

    /// <inheritdoc />
    public void Set(string key, float value)
    {
        _configurations.Remove(key);
        _configurations.Add(key, value.ToString(CultureInfo.InvariantCulture));
    }

    /// <inheritdoc />
    public void Set(string key, double value)
    {
        _configurations.Remove(key);
        _configurations.Add(key, value.ToString(CultureInfo.InvariantCulture));
    }

    /// <inheritdoc />
    public void Set(string key, Vector2 value)
    {
        _configurations.Remove(key);
        _configurations.Add(key, value.ToString());
    }

    /// <inheritdoc />
    public void Set(string key, Vector3 value)
    {
        _configurations.Remove(key);
        _configurations.Add(key, value.ToString());
    }

    /// <inheritdoc />
    public void Set(string key, Vector4 value)
    {
        _configurations.Remove(key);
        _configurations.Add(key, value.ToString());
    }

    /// <inheritdoc />
    public void Set(string key, Matrix2 value)
    {
        _configurations.Remove(key);
        _configurations.Add(key, value.ToString());
    }

    /// <inheritdoc />
    public void Set(string key, Matrix3 value)
    {
        _configurations.Remove(key);
        _configurations.Add(key, value.ToString());
    }

    /// <inheritdoc />
    public void Set(string key, Matrix4 value)
    {
        _configurations.Remove(key);
        _configurations.Add(key, value.ToString());
    }

    /// <inheritdoc />
    public void Set(string key, Color value)
    {
        _configurations.Remove(key);
        _configurations.Add(key, value.ToString());
    }

    #endregion
}
