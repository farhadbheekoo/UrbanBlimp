using System;
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
                           Alias = (string)jsonValue.Value("alias"),
                           Active = (bool)jsonValue.Value("active"),
                           Created = (DateTime)jsonValue.Value("created"),
                           Tags = Dynamic.ToList(jsonValue.Value("tags")),
                       };
        }

    }
}