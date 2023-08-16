using System.Text;
using Engine.Core.Configurations.Interface;
using Newtonsoft.Json.Linq;

namespace Engine.Core.Configurations.Loader;

/// <summary>
///     <see cref="IConfigurationBuilder" /> implementation to load *.json files
/// </summary>
public sealed class JsonBuilder : IConfigurationBuilder
{
    private readonly string _loadPath;

    /// <inheritdoc />
    public string Extension => "json";

    /// <summary>
    ///     Create new instance of <see cref="IniBuilder" />
    /// </summary>
    public JsonBuilder()
    {
        _loadPath = $"settings.{Extension}";
    }

    /// <inheritdoc />
    public IDictionary<string, string> Load(string path)
    {
        var file = File.ReadAllText(path);
        var json = JObject.Parse(file);

        var result = new Dictionary<string, string>();
        foreach (var (key, value) in json)
        {
            if (value is JObject jObject)
            {
                foreach (var (subKey, subValue) in jObject)
                {
                    result.Add($"{key}.{subKey}", subValue?.ToString() ?? string.Empty);
                }
            }
            else
            {
                result.Add(key, value?.ToString() ?? string.Empty);
            }
        }

        return result;
    }

    /// <inheritdoc />
    public ReadOnlySpan<char> Build(IDictionary<string, string> configuration)
    {
        var groups = configuration.GroupBy(pair => pair.Key.Split('.')[0]);
        var writer = new StringBuilder();
        writer.AppendLine("{");

        var pairs = groups as IGrouping<string, KeyValuePair<string, string>>[] ?? groups.ToArray();
        foreach (var group in pairs)
        {
            writer.AppendLine($"\t\"{group.Key}\": {{");

            foreach (var values in group)
            {
                var keyName = values.Key[(group.Key.Length + 1)..];
                if (values.Key == pairs.Last().Key)
                {
                    writer.AppendLine($"\t\t\"{keyName}\": \"{values.Value}\"");
                }
                else
                {
                    writer.AppendLine($"\t\t\"{keyName}\": \"{values.Value}\",");
                }
            }

            writer.AppendLine("\t}");
        }

        writer.AppendLine("}");

        return writer.ToString();
    }
}
