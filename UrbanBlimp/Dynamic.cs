using System;
using System.Collections.Generic;
using System.Globalization;
using System.Json;

namespace UrbanBlimp
{
    static class Dynamic
    {

        public static DateTime? DateValue(this JsonValue json, string key)
        {

            if (!json.ContainsKey(key))
            {
                return null;
            }
            var value = (string)json[key];

            return DateTime.ParseExact(value, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        }

        public static int? IntValue(this JsonValue json, string key)
        {
            if (json.ContainsKey(key))
            {
                // ReSharper disable RedundantCast
                return (int?) json[key];
                // ReSharper restore RedundantCast
            }
            return null;
        }

        public static List<string> ListValue(this JsonValue jsonValue, string key)
        {

            if (!jsonValue.ContainsKey(key))
            {
                return null;
            }
            var value = jsonValue[key];
            var list = new List<string>();
            for (var index = 0; index < value.Count; index++)
            {
// ReSharper disable RedundantCast
                list.Add((string) value[index]);
// ReSharper restore RedundantCast
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

        public static string StringValue(this JsonValue jsonValue, string key)
        {
            if (jsonValue.ContainsKey(key))
            {
                // ReSharper disable RedundantCast
                return (string) jsonValue[key];
                // ReSharper restore RedundantCast
            }
            return null;
        }

        public static bool BoolValue(this JsonValue jsonValue, string key)
        {
            if (jsonValue.ContainsKey(key))
            {
                // ReSharper disable RedundantCast
                return (bool) jsonValue[key];
                // ReSharper restore RedundantCast
            }
            return false;
        }

    }
}