using System.IO;
using System.Json;

namespace UrbanBlimp.Android
{
    internal static class RegistrationDeSerializer
    {

        public static Registration DeSerialize(Stream content)
        {
            var jsonValue = JsonValue.Load(content);
            return new Registration
                       {
                           Alias = jsonValue.StringValue("alias"),
                           Active = jsonValue.BoolValue("active"),
                           Created = jsonValue.DateValue("created").Value,
                           Tags = jsonValue.ListValue("tags"),
                       };
        }

    }
}