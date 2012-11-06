using System;
using Newtonsoft.Json.Linq;

public static class JsonPretty
{
    public static string FormatAsJsom(this string value)
    {
        string formatted;
        if (value.StartsWith("["))
        {
            formatted = JArray.Parse(value).ToString();
        }
        else
        {

            formatted = JObject.Parse(value).ToString();
        }
        var formatAsJsom = Environment.NewLine + formatted.Replace("\"", "'");
        return formatAsJsom.Replace("\n", "\r\n");
    }
}