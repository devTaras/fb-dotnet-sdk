using System.Text.Json.Serialization;

namespace GraphApi.Facebook.Client.GraphApi
{
    /// <summary>
    /// When making an API request to a node or edge, you usually don't receive all of the results
    /// of that request in a single response. This is because some responses could contain thousands
    /// of objects so most responses are paginated by default.
    /// </summary>
    class Paging
    {
        /// <summary>
        /// The Graph API endpoint that will return the next page of data.
        /// If not included, this is the last page of data. 
        /// Due to how pagination works with visibility and privacy, 
        /// it is possible that a page may be empty but contain a <see cref="Next"/> paging link.
        /// Stop paging when the <see cref="Next"/> link no longer appears.
        /// </summary>
        [JsonPropertyName("next")]
        public string Next { get; set; }

        /// <summary>
        /// The Graph API endpoint that will return the previous page of data.
        /// If not included, this is the first page of data.
        /// </summary>
        [JsonPropertyName("previous")]
        public string Previous { get; set; }

        /// <summary>
        /// This is the maximum number of objects that may be returned.
        /// A query may return fewer than the value of limit due to filtering.
        /// Do not depend on the number of results being fewer than the <see cref="Limit"/> value
        /// to indicate that your query reached the end of the list of data,
        /// use the absence of <see cref="Next"/> instead as described below. For example,
        /// if you set <see cref="Limit"/> to 10 and 9 results are returned,
        /// there may be more data available, but one item was removed due to privacy filtering.
        /// Some edges may also have a maximum on the limit value for performance reasons.
        /// In all cases, the API returns the correct pagination links.
        /// </summary>
        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        /// <summary>
        /// Cursor-based pagination is the most efficient method of paging and should always be used when possible.
        /// A cursor refers to a random string of characters which marks a specific item in a list of data. 
        /// The cursor will always point to the item, however it will be invalidated if the item is deleted or removed.
        /// Therefore, your app shouldn't store cursors or assume that they will be valid in the future.
        /// </summary>
        [JsonPropertyName("cursors")]
        public Cursor Cursor { get; set; }
    }
}
