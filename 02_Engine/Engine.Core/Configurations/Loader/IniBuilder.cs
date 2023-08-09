using System.Text;
using Engine.Core.Configurations.Interface;

namespace Engine.Core.Configurations.Loader;

/// <summary>
/// <see cref="IConfigurationBuilder" /> implementation to load *.ini files
/// </summary>
public sealed class IniBuilder : IConfigurationBuilder
{
    private string _loadPath;

    /// <summary>
    /// Create new instance of <see cref="IniBuilder" />
    /// </summary>
    public IniBuilder()
    {
        _loadPath = $"settings.{Extension}";
    }

    /// <inheritdoc />
    public string Extension
    {
        get { return "ini"; }
    }

    /// <inheritdoc />
    public IDictionary<string, string> Load(string path)
    {
        _loadPath = path;
        var textData = File.ReadAllLines(_loadPath);
        var actualGroup = "";
        var result = new Dictionary<string, string>();

        foreach (var line in textData)
        {
            var currentLine = line.Trim();

            if (!string.IsNullOrEmpty(currentLine))
            {
                if (currentLine.StartsWith('[') &&
                    currentLine.EndsWith(']'))
                {
                    actualGroup = currentLine[1..^1].Trim();
                }

                if (currentLine.Contains('='))
                {
                    var keyValueSplit = currentLine.Split('=');
                    if (keyValueSplit.Length > 0)
                    {
                        var name = keyValueSplit[0].Trim();
                        var value = keyValueSplit[1].Trim();
                        result.Add($"{actualGroup}.{name}", value);
                    }
                }
            }
        }

        return result;
    }

    /// <inheritdoc />
    public ReadOnlySpan<char> Build(IDictionary<string, string> configuration)
    {
        var groups = configuration.GroupBy(pair => pair.Key.Split('.')[0]);
        var writer = new StringBuilder();

        foreach (var group in groups)
        {
            writer.AppendLine($"[{group.Key}]");

            foreach (var values in group)
            {
                var keyName = values.Key[(group.Key.Length + 1)..];
                writer.AppendLine($"{keyName}={values.Value}");
            }

            writer.AppendLine("");
        }

        return writer.ToString();
    }
}
