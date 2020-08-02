using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GraphApi.Facebook.GraphApi.User.Models.Request
{
    public class UserProfilePictureOptions
    {
        /// <summary>
        /// The height of this picture in pixels.
        /// </summary>
        [JsonPropertyName("height")]
        public int? Height { get; set; }

        /// <summary>
        /// The width of this picture in pixels.
        /// </summary>
        [JsonPropertyName("width")]
        public int? Width { get; set; }

        /// <summary>
        /// The size of this picture.
        /// It can be one of the following values: small, normal, large, square.
        /// </summary>
        [JsonPropertyName("type")]
        public PictureSizeType? Type { get; set; }
    }

    public enum PictureSizeType
    {
        Small,
        Normal,
        Album,
        Large,
        Square
    }
}
