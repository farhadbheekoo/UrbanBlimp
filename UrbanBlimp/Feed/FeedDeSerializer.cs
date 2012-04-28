using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Linq;

namespace UrbanBlimp.Feed
{
    static class FeedDeSerializer
    {

        public static IEnumerable<Feed> DeSerialize(Stream content)
        {
            var array = JsonValue.Load(content);

            foreach (var value in array.Select(x => x.Value))
            {
                yield return DeSerializeFeed(value);
            }
        }

        static Feed DeSerializeFeed(JsonValue value)
        {
            return new Feed
                       {
                           Url = (string) value.Value("url"),
                           Id = (string) value.Value("id"),
                           Template = DeSerializeTemplate(value.Value("template")),
                           FeedUrl = (string) value.Value("feed_url"),
                           BroadCast = (bool)value.Value("broadcast"),
                           LastChecked = value.DateValue("last_checked").Value
                       };
        }

        static Template DeSerializeTemplate(JsonValue value)
        {
            return new Template
                       {
                           FeedPayload = DeSerializePayload(value.Value("aps")),
                           Tags = value.ListValue("tags")
                       };
        }

        static FeedPayload DeSerializePayload(JsonValue value)
        {
            return new FeedPayload
                       {
                           Alert = (string) value.Value("alert"),
                           Badge = (int?) value.Value("badge"),
                           Sound = (string) value.Value("sound"),
                       };
        }
    }
}