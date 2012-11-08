using System.Collections.Generic;
using System.IO;
using System.Json;

namespace UrbanBlimp.Apple
{

    internal static class FeedbackSerializer
    {

        public static IEnumerable<DeviceFeedback> DeSerialize(Stream content)
        {
            if (content == null)
            {
                yield break;
            }
            var jsonValue = JsonValue.Load(content);

            for (var index = 0; index < jsonValue.Count; index++)
            {
                var token = jsonValue[index];
                yield return new DeviceFeedback
                                 {
                                     Alias = token.StringValue("alias"),
                                     DeviceToken = token.StringValue("device_token"),
                                     MakedInactiveOn = token.DateValue("marked_inactive_on")
                                 };
            }
        }

    
    }
}