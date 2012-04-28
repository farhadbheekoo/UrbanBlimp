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
                           Url = jsonValue.StringValue("url"),
                           Id = jsonValue.StringValue("id"),
                           LastChecked = jsonValue.DateValue("last_checked")
                       };
        }

    }
}