using System.Collections.Generic;
using System.IO;
using System.Json;

namespace UrbanBlimp.Apple
{

    internal static class FeedbackSerializer
    {

        public static IEnumerable<DeviceFeedback> DeSerialize(Stream content)
        {
            var jsonValue = JsonValue.Load(content);

            var tokens = jsonValue["device_tokens"];
            for (var index = 0; index < tokens.Count; index++)
            {
                var token = tokens[index];
                yield return new DeviceFeedback
                                 {
                                     Alias = (string)token.Value("alias"),
                                     DeviceToken = (string)token.Value("device_token"),
                                     MakedInactiveOn = DateTimeExtensions.ParseDate((string)token.Value("marked_inactive_on"))
                                 };
            }
        }

    
    }
}