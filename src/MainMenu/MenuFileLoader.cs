using System.Text.Json;
using System.Xml.Linq;

namespace MainMenu;

internal static class MenuFileLoader
{
    public static Dictionary<string, string> LoadFromSeparatedFile(string path, char separator)
    {
        EnsureFileExists(path);

        var options = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach (var rawLine in File.ReadAllLines(path))
        {
            string line = rawLine.Trim();
            if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
            {
                continue;
            }

            int separatorIndex = line.IndexOf(separator);
            if (separatorIndex <= 0 || separatorIndex == line.Length - 1)
            {
                continue;
            }

            string key = line[..separatorIndex].Trim();
            string value = line[(separatorIndex + 1)..].Trim();
            if (key.Length == 0 || value.Length == 0)
            {
                continue;
            }

            options[key] = value;
        }

        return ValidateOptions(options, path);
    }

    public static Dictionary<string, string> LoadFromXml(string path)
    {
        EnsureFileExists(path);

        var doc = XDocument.Load(path);
        var options = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        foreach (var option in doc.Descendants("option"))
        {
            string? key = option.Attribute("key")?.Value ?? option.Element("key")?.Value;
            string? value = option.Attribute("value")?.Value
                ?? option.Attribute("text")?.Value
                ?? option.Element("value")?.Value
                ?? option.Element("text")?.Value;

            if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(value))
            {
                continue;
            }

            options[key.Trim()] = value.Trim();
        }

        return ValidateOptions(options, path);
    }

    public static Dictionary<string, string> LoadFromJson(string path)
    {
        EnsureFileExists(path);

        string json = File.ReadAllText(path);
        using JsonDocument doc = JsonDocument.Parse(json);
        var options = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        if (doc.RootElement.ValueKind == JsonValueKind.Object)
        {
            foreach (var property in doc.RootElement.EnumerateObject())
            {
                if (property.Value.ValueKind == JsonValueKind.String)
                {
                    options[property.Name.Trim()] = property.Value.GetString()!.Trim();
                }
            }
        }
        else if (doc.RootElement.ValueKind == JsonValueKind.Array)
        {
            foreach (var item in doc.RootElement.EnumerateArray())
            {
                if (item.ValueKind != JsonValueKind.Object)
                {
                    continue;
                }

                if (!item.TryGetProperty("key", out var keyElement) || keyElement.ValueKind != JsonValueKind.String)
                {
                    continue;
                }

                if (!item.TryGetProperty("value", out var valueElement) || valueElement.ValueKind != JsonValueKind.String)
                {
                    continue;
                }

                options[keyElement.GetString()!.Trim()] = valueElement.GetString()!.Trim();
            }
        }

        return ValidateOptions(options, path);
    }

    private static Dictionary<string, string> ValidateOptions(Dictionary<string, string> options, string source)
    {
        if (options.Count == 0)
        {
            throw new InvalidOperationException($"File '{source}' does not contain valid options.");
        }

        if (!options.ContainsKey("x"))
        {
            options["x"] = "To exit";
        }

        return options;
    }

    private static void EnsureFileExists(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException("Menu file was not found.", path);
        }
    }
}
