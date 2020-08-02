using System.Text.Json.Serialization;

namespace GraphApi.Facebook.Client.GraphApi.User.Models
{
    public class AgeRange
    {
        /// <summary>
        /// The lower bounds of the range for this person's age.
        /// </summary>
        [JsonPropertyName("min")]
        public MinAge? MinAge { get; set; }
        /// <summary>
        /// The upper bounds of the range for this person's age.
        /// </summary>
        [JsonPropertyName("max")]
        public MaxAge? MaxAge { get; set; }
    }

    public enum MinAge
    {
        Seventeen = 17,
        Twenty = 20,
    }

    public enum MaxAge
    {
        Thirteen = 13,
        Eighteen = 18,
        TwentyOne = 21
    }
}