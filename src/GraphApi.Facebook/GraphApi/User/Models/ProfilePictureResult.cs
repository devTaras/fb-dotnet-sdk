using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GraphApi.Facebook.GraphApi.User.Models
{
    public class ProfilePictureResult
    {
        /// <summary>
        /// Picture height in pixels. Only returned when specified as a modifier
        /// </summary>
        [JsonPropertyName("height")]
        public uint? Height { get; set; }

        /// <summary>
        /// A key to identify the profile picture for the purpose of invalidating the image cache
        /// </summary>
        [JsonPropertyName("cache_key")]
        public string CacheKey { get; set; }

        /// <summary>
        /// True if the profile picture is the default 'silhouette' picture
        /// </summary>
        [JsonPropertyName("is_silhouette")]
        public bool IsSilhouette { get; set; }

        /// <summary>
        /// URL of the profile picture. The URL will expire.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// Picture width in pixels. Only returned when specified as a modifier
        /// </summary>
        [JsonPropertyName("width")]
        public uint? Width { get; set; }

    }
}
