using System.Text.Json.Serialization;

namespace GraphApi.Facebook.Client.GraphApi
{
    class DataWrapper<T>
    {
        [JsonPropertyName("data")]
        public T Data { get; set; }

        [JsonPropertyName("paging")]
        public Paging Paging { get; set; }
    }
}
