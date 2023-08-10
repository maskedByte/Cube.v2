using System.Text;
using Engine.Core.Configurations.Interface;
using Engine.Core.Exceptions;

namespace Engine.Core.Configurations.Loader;

/// <summary>
///     <see cref="IConfigurationBuilder" /> implementation to load *.yml files
/// </summary>
public sealed class YamlBuilder : IConfigurationBuilder
{
    private readonly string _loadPath;

    /// <inheritdoc />
    public string Extension => "yml;yaml";

    /// <summary>
    ///     Create new instance of <see cref="IniBuilder" />
    /// </summary>
    public YamlBuilder()
    {
        _loadPath = $"settings.{Extension}";
    }

    /// <inheritdoc />
    public IDictionary<string, string> Load(string path)
    {
        /*
         * This loads a configuration file in the following format from yml:
         *
         * GroupName:
         *   KeyName: Value
         *   KeyName: Value
         *
         * GroupName2:
         *   KeyName: Value
         *
         */

        var config = new Dictionary<string, string>();
        var lines = File.ReadAllLines(path);

        var group = string.Empty;
        foreach (var line in lines)
        {
            var currentLine = line.Trim();

            if (currentLine.StartsWith('#') || string.IsNullOrWhiteSpace(currentLine))
            {
                continue;
            }

            if (currentLine.EndsWith(':'))
            {
                group = currentLine[..^1];
                continue;
            }

            var keyValuePair = currentLine.Split(':');
            if (keyValuePair.Length != 2)
            {
                throw new InvalidConfigurationException(path);
            }

            var key = $"{group}.{keyValuePair[0].Trim()}";
            var value = keyValuePair[1].Trim();

            config.TryAdd(key, value);
        }

        return config;
    }

    /// <inheritdoc />
    public ReadOnlySpan<char> Build(IDictionary<string, string> configuration)
    {
        var groups = configuration.GroupBy(pair => pair.Key.Split('.')[0]);
        var writer = new StringBuilder();

        var enumerable = groups as IGrouping<string, KeyValuePair<string, string>>[] ?? groups.ToArray();
        foreach (var group in enumerable)
        {
            writer.AppendLine($"{group.Key}:");

            foreach (var values in group)
            {
                var keyName = values.Key[(group.Key.Length + 1)..];

                writer.AppendLine($"\t{keyName}: {values.Value}");
            }

            writer.AppendLine();
        }

        return writer.ToString();
    }
}
