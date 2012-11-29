using System.IO;
using System.Json;

namespace UrbanBlimp.Feed
{
    static class GetFeedResponseDeSerializer
    {


        public static GetFeedResponse DeSerialize(Stream content)
        {
            if (content == null)
            {
                return null;
            }
                return DeSerializeFeed(JsonValue.Load(content));
        }

        static GetFeedResponse DeSerializeFeed(JsonValue value)
        {
            return new GetFeedResponse
                       {
                           Url = value.StringValue("url"),
                           Id = value.StringValue("id"),
                           Template = DeSerializeTemplate(value["template"]),
                           FeedUrl = value.StringValue("feed_url"),
                           BroadCast = value.BoolValue("broadcast"),
// ReSharper disable PossibleInvalidOperationException
                           LastChecked = value.NullableDateValue("last_checked").Value
// ReSharper restore PossibleInvalidOperationException
                       };
        }

        static Template DeSerializeTemplate(JsonValue value)
        {
            return new Template
                       {
                           FeedPayload = DeSerializePayload(value["aps"]),
                           Tags = value.ListValue("tags")
                       };
        }

        static FeedPayload DeSerializePayload(JsonValue value)
        {
            return new FeedPayload
                       {
                           Alert = value.StringValue("alert"),
                           Badge = value.NullIntValue("badge"),
                           Sound = value.StringValue("sound"),
                       };
        }
    }
}