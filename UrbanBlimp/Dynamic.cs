using System.Collections.Generic;
using System.Json;

namespace UrbanBlimp
{
    static class Dynamic
    {
        

        public static List<string> ToList(JsonValue value)
        {
            if (value == null)
            {
                return null;
            }

            var list = new List<string>();
            for (var index = 0; index < value.Count; index++)
            {
                list.Add((string) value[index]);
            }
            return list;
        }

        public static JsonArray ToJsonArray(this List<string> list)
        {
            var tagArray = new JsonArray();
            foreach (var tag in list)
            {
                tagArray.Add(tag);
            }
            return tagArray;

        }
        public static JsonValue Value(this JsonValue jsonValue, string key)
        {
            if (key == null)
            {
                return null;
            }
            if (jsonValue.ContainsKey(key))
            {
                return jsonValue[key];
            }
            return null;
        }

 

    }
}