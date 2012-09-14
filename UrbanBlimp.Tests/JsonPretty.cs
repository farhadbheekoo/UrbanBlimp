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
        return "\r\n" + formatted.Replace("\"","'");
    }
}