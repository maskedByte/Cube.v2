using System.Text;
using System.Xml.Linq;
using Engine.Core.Configurations.Interface;
using Engine.Core.Exceptions;

namespace Engine.Core.Configurations.Loader;

/// <summary>
/// <see cref="IConfigurationBuilder" /> implementation to load *.xml files
/// </summary>
public sealed class XmlBuilder : IConfigurationBuilder
{
    private readonly string _loadPath;

    /// <summary>
    /// Create new instance of <see cref="IniBuilder" />
    /// </summary>
    public XmlBuilder()
    {
        _loadPath = $"settings.{Extension}";
    }

    /// <inheritdoc />
    public string Extension
    {
        get { return "xml"; }
    }

    /// <inheritdoc />
    public IDictionary<string, string> Load(string path)
    {
        var document = XDocument.Load(path);
        var root = document.Root;

        if (root == null)
        {
            throw new InvalidConfigurationException(path);
        }

        var settings = root.Elements();
        var result = new Dictionary<string, string>();

        foreach (var setting in settings)
        {
            var group = setting.Name.LocalName;
            var entries = setting.Elements();

            foreach (var entry in entries)
            {
                var name = entry.Attribute("name")?.Value;
                var value = entry.Attribute("value")?.Value;

                if (name == null || value == null)
                {
                    throw new InvalidConfigurationException(path);
                }

                result.Add($"{group}.{name}", value);
            }
        }

        return result;
    }

    /// <inheritdoc />
    public ReadOnlySpan<char> Build(IDictionary<string, string> configuration)
    {
        var groups = configuration.GroupBy(pair => pair.Key.Split('.')[0]);
        var writer = new StringBuilder();
        writer.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
        writer.AppendLine("<Settings>");

        var enumerables = groups as IGrouping<string, KeyValuePair<string, string>>[] ?? groups.ToArray();
        foreach (var group in enumerables)
        {
            writer.AppendLine($"\t<{group.Key}>");

            foreach (var values in group)
            {
                var keyName = values.Key[(group.Key.Length + 1)..];

                writer.AppendLine($"\t\t<Entry name=\"{keyName}\" value=\"{values.Value}\" />");
            }

            writer.AppendLine($"\t</{group.Key}>");
        }

        writer.AppendLine("</Settings>");

        return writer.ToString();
    }
}
