using System.Collections.Generic;
using System.IO;
using System.Json;

namespace UrbanBlimp.Tag
{

    internal static class TagDeSerializer
    {

        public static IEnumerable<string> DeSerialize(Stream content)
        {
            if (content == null)
            {
                yield break;
            }
            var jsonValue = JsonValue.Load(content);

            var tokens = jsonValue["tags"];

            for (var index = 0; index < tokens.Count; index++)
            {
                yield return (string) tokens[index];
            }
        }

    
    }
}