using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Linq;

namespace UrbanBlimp.Apple
{

    static class FeedbackResponseDeSerializer
    {
   
        public static FeedbackResponse DeSerialize(Stream content)
        {
            return new FeedbackResponse
                       {
                           DeviceFeedbacks = GetDeviceFeedbacks(content).ToList()
                       };
        }

        static IEnumerable<DeviceFeedback> GetDeviceFeedbacks(Stream content)
        {
            if (content == null)
            {
                yield return null;
            }
            var jsonValue = JsonValue.Load(content);

            for (var index = 0; index < jsonValue.Count; index++)
            {
                var token = jsonValue[index];
                yield return new DeviceFeedback
                                 {
                                     Alias = token.StringValue("alias"),
                                     DeviceToken = token.StringValue("device_token"),
                                     MakedInactiveOn = token.NullableDateValue("marked_inactive_on")
                                 };
            }
        }
    }
}