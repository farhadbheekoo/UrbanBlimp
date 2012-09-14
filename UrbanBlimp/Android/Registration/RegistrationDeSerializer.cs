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
// ReSharper disable PossibleInvalidOperationException
                           Created = jsonValue.DateValue("created").Value,
// ReSharper restore PossibleInvalidOperationException
                           Tags = jsonValue.ListValue("tags"),
                       };
        }

    }
}