using System.IO;
using System.Json;

namespace UrbanBlimp.Feed
{
    static class CreateFeedResponseDeSerializer
    {

        public static CreateFeedResponse DeSerialize(Stream content)
        {
            var jsonValue = JsonValue.Load(content);
            return new CreateFeedResponse
                       {
                           Url = jsonValue.StringValue("url"),
                           Id = jsonValue.StringValue("id"),
                           LastChecked = jsonValue.NullableDateValue("last_checked")
                       };
        }

    }
}