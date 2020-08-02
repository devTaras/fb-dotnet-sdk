using System.Text.Json.Serialization;

namespace GraphApi.Facebook.Client.GraphApi
{
    /// <summary>
    /// Cursor-based pagination is the most efficient method of paging and should always be used when possible.
    /// A cursor refers to a random string of characters which marks a specific item in a list of data.
    /// The cursor will always point to the item, however it will be invalidated if the item is deleted or removed.
    /// Therefore, your app shouldn't store cursors or assume that they will be valid in the future.
    /// </summary>
    class Cursor
    {
        /// <summary>
        /// This is the cursor that points to the start of the page of data that has been returned
        /// </summary>
        [JsonPropertyName("before")]
        public string Before { get; set; }

        /// <summary>
        /// This is the cursor that points to the end of the page of data that has been returned.
        /// </summary>
        [JsonPropertyName("after")]
        public string After { get; set; }

        

    }
}
