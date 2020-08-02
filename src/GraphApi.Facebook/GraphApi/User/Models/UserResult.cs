using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace GraphApi.Facebook.Client.GraphApi.User.Models
{
    /// <summary>
    /// Represents a Facebook user
    /// </summary>
    public class UserResult
    {
        /// <summary>
        /// The ID of this person's user account.
        /// This ID is unique to each app and cannot be used across different apps.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The age segment for this person expressed as a minimum and maximum age.
        /// For example, more than 18, less than 21.
        /// </summary>
        [JsonPropertyName("age_range")]
        public AgeRange AgeRange { get; set; }

        /// <summary>
        /// The person's birthday. This is a fixed format string, like MM/DD/YYYY.
        /// However, people can control who can see the year they were born separately
        /// from the month and day so this string can be only the year (YYYY)
        /// or the month + day (MM/DD)
        /// </summary>
        [JsonPropertyName("birthday")]
        public string Birthday { get; set; }

        /// <summary>
        /// The User's primary email address listed on their profile.
        /// This field will not be returned if no valid email address is available.
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// The person's first name
        /// </summary>
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// The gender selected by this person, male or female.
        /// If the gender is set to a custom value,
        /// this value will be based off of the preferred pronoun;
        /// it will be omitted if the preferred pronoun is neutral
        /// </summary>
        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        /// <summary>
        /// The person's last name
        /// </summary>
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// A link to the person's Timeline.
        /// The link will only resolve if the person clicking the link
        /// is logged into Facebook and is a friend of the person whose
        /// profile is being viewed.
        /// </summary>
        [JsonPropertyName("link")]
        public string Link { get; set; }

        /// <summary>
        /// The person's middle name
        /// </summary>
        [JsonPropertyName("middle_name")]
        public string MiddleName { get; set; }

        /// <summary>
        /// The person's full name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        ///// <summary>
        ///// The profile picture URL of the Messenger user. The URL will expire.
        ///// </summary>
        //[JsonPropertyName("profile_pic")]
        //public string ProfilePicUrl { get; set; }

        /// <summary>
        /// Shortened, locale-aware name for the person
        /// </summary>
        [JsonPropertyName("short_name")]
        public string ShortName { get; set; }

        
    }
}
