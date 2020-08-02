using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace GraphApi.Facebook.GraphApi.Helpers
{
    internal static class ModelHelper
    {
        internal static IEnumerable<string> GetAllModelFields<T>()
        {
            return typeof(T).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
                .Select(x => x
                    .GetCustomAttributes(typeof(JsonPropertyNameAttribute), false)
                    .Cast<JsonPropertyNameAttribute>().First().Name);
        }

        internal static IEnumerable<KeyValuePair<string, string>> GetOptionsAsKeyValue<T>(T model)
        {
            return typeof(T).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
                .Where(x => x.GetCustomAttributes(typeof(JsonPropertyNameAttribute), false).Length > 0 && x.GetValue(model) != null)
                .Select(prop => 
                    new KeyValuePair<string, string>(
                        key: prop.GetCustomAttributes(typeof(JsonPropertyNameAttribute), false)
                                .Cast<JsonPropertyNameAttribute>().First().Name,
                        value: prop.GetValue(model).ToRequiredString()));
        }

        private static string ToRequiredString(this object value)
        {
            if (value.GetType().IsEnum)
                return value.ToString().ToLower();
            else
                return value.ToString();
        }
    }
}
