using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Linq;

namespace UrbanBlimp.Apple
{

    static class GetRegistrationsResponseDeSerializer
    {

        public static GetRegistrationsResponse DeSerialize(Stream content)
        {
            if (content == null)
            {
                return new GetRegistrationsResponse();
            }
            var jsonValue = JsonValue.Load(content);

            return new GetRegistrationsResponse
                       {
                           Devices = RegistrationSummaries(jsonValue).ToList(),
                           NextPage = jsonValue.StringValue("next_page"),
                           DeviceTokensCount = jsonValue.IntValue("device_tokens_count"),
                           ActiveDeviceTokensCount = jsonValue.IntValue("active_device_tokens_count"),
                       };
        }


        static IEnumerable<RegistrationSummary> RegistrationSummaries(JsonValue jsonValue)
        {
            var tokens = jsonValue["device_tokens"];
            for (var index = 0; index < tokens.Count; index++)
            {
                var token = tokens[index];
                yield return new RegistrationSummary
                                 {
                                     Alias = token.StringValue("alias"),
                                     DeviceToken = token.StringValue("device_token"),
                                     IsActive = token.BoolValue("active"),
                                     Tags = token.ListValue("tags"),
                                 };
            }
        }
    }
}