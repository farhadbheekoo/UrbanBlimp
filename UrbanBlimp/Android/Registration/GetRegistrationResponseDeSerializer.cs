using System.IO;
using System.Json;

namespace UrbanBlimp.Android
{
    static class GetRegistrationResponseDeSerializer
    {

        public static GetRegistrationResponse DeSerialize(Stream content)
        {
            var jsonValue = JsonValue.Load(content);
            return new GetRegistrationResponse
                       {
                           Alias = jsonValue.StringValue("alias"),
                           Active = jsonValue.BoolValue("active"),
// ReSharper disable PossibleInvalidOperationException
                           Created = jsonValue.NullableDateValue("created").Value,
// ReSharper restore PossibleInvalidOperationException
                           Tags = jsonValue.ListValue("tags"),
                       };
        }

    }
}