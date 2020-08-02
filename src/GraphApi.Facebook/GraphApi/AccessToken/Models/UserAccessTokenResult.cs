using System;
using System.Text.Json.Serialization;
using GraphApi.Facebook.Client.JsonConverters;

namespace GraphApi.Facebook.Client.GraphApi.AccessToken.Models
{
    public class UserAccessTokenResult
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        [JsonPropertyName("expires_in")]
        [JsonConverter(typeof(SecondsLeftJsonConverter))]
        public DateTime ExpiresIn { get; set; }
    }
}
