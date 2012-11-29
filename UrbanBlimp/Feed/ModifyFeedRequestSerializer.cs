using System.Json;

namespace UrbanBlimp.Feed
{
    static class ModifyFeedRequestSerializer
    {

        public static string Serialize(this ModifyFeedRequest newFeed)
        {
            var jsonObj = JsonObj(newFeed);
            return jsonObj.ToString();
        }


        static JsonObject JsonObj(ModifyFeedRequest newFeed)
        {
            var jsonObj = new JsonObject();
            jsonObj["template"] = CreateFeedRequestSerializer.SerializeTemplate(newFeed.Template);
            jsonObj["feed_url"] = newFeed.FeedUrl;
            jsonObj["url"] = newFeed.Url;
            jsonObj["broadcast"] = newFeed.BroadCast;
            return jsonObj;
        }

    }
}