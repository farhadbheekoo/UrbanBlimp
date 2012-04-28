using System.IO;
using System.Json;

namespace UrbanBlimp.Feed
{
    internal static class NewFeedIdDeSerializer
    {

        public static NewFeedId DeSerialize(Stream content)
        {
            var jsonValue = JsonValue.Load(content);
            return new NewFeedId
                       {
                           Url = (string) jsonValue.Value("url"),
                           Id = (string)jsonValue.Value("id"),
                           LastChecked = jsonValue.DateValue("last_checked")
                       };
        }

    }
}