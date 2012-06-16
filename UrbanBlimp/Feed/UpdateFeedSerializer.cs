using System.IO;
using System.Json;

namespace UrbanBlimp.Feed
{
    internal static class UpdateFeedSerializer
    {

        public static string Serialize(UpdateFeed newFeed)
        {
            var jsonObj = JsonObj(newFeed);
            return jsonObj.ToString();
        }
        public static void Serialize(this UpdateFeed newFeed, Stream stream)
        {
            var jsonObj = JsonObj(newFeed);
            jsonObj.Save(stream);
        }

        static JsonObject JsonObj(UpdateFeed newFeed)
        {
            var jsonObj = new JsonObject();
            jsonObj["template"] = NewFeedSerializer.SerializeTemplate(newFeed.Template);
            jsonObj["feed_url"] = newFeed.FeedUrl;
            jsonObj["url"] = newFeed.Url;
            jsonObj["broadcast"] = newFeed.BroadCast;
            return jsonObj;
        }

    }
}