using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using GraphApi.Facebook.Client.JsonConverters;

namespace GraphApi.Facebook.Client.GraphApi.DebugToken.Models
{
    public class DebugTokenResult
    {
        /// <summary>
        /// The ID of the application this access token is for.
        /// </summary>
        [JsonPropertyName("app_id")]
        public string AppId { get; set; }

        /// <summary>
        /// Token Type
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Name of the application this access token is for.
        /// </summary>
        [JsonPropertyName("application")]
        public string ApplicationName { get; set; }

        /// <summary>
        /// Timestamp/DateTime when app's access to user data expires.
        /// </summary>
        [JsonPropertyName("data_access_expires_at")]
        [JsonConverter(typeof(TimestampJsonConverter))]
        public DateTime DataAccessExpiresDateTime { get; set; }

        /// <summary>
        /// Timestamp/DateTime when this access token expires.
        /// </summary>
        [JsonPropertyName("expires_at")]
        [JsonConverter(typeof(TimestampJsonConverter))]
        public DateTime ExpiresDateTime { get; set; }

        /// <summary>
        /// Whether the access token is still valid or not.
        /// </summary>
        [JsonPropertyName("is_valid")]
        public bool IsValid { get; set; }

        /// <summary>
        /// For impersonated access tokens, the ID of the page this token contains.
        /// </summary>
        [JsonPropertyName("profile_id")]
        public string ProfileId { get; set; }

        /// <summary>
        /// List of permissions that the user has granted for the app in this access token.
        /// </summary>
        [JsonPropertyName("scopes")]
        public List<string> Scopes { get; set; }

        /// <summary>
        /// List of granular permissions that the user has granted for the app in this access token.
        /// If permission applies to all, targets will not be shown.
        /// </summary>
        [JsonPropertyName("granular_scopes")]
        public List<GranularScope> GranularScopes { get; set; }

        /// <summary>
        /// The ID of the user this access token is for.
        /// </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
    }

    public class GranularScope
    {
        [JsonPropertyName("scope")]
        public string Scope { get; set; }
        [JsonPropertyName("target_ids")]
        public List<string> TargetIds { get; set; }
    }
}
