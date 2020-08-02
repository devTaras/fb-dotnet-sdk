using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GraphApi.Facebook.Client.JsonConverters
{
    class SecondsLeftJsonConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Number && reader.TryGetInt64(out var result))
            {
                return DateTime.Now.AddSeconds(result - 60);
            }

            throw new JsonException($"Expected number, but got {reader.TokenType}");
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(new TimeSpan(DateTime.Now.Ticks - value.Ticks).TotalSeconds);
        }
    }
}
