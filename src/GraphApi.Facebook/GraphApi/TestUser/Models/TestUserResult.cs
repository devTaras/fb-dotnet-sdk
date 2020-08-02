using System.Text.Json.Serialization;

namespace GraphApi.Facebook.GraphApi.TestUser.Models
{
    public class TestUserResult
    {
        /// <summary>
        /// The user ID of the test user
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The access token for the test user and this app.
        /// This field is only visible if the test user has installed the app.
        /// </summary>
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// This URL will allow the test user account to be logged into.
        /// The URL will expire one hour after it is generated,
        /// or after the first time it is used.
        /// </summary>
        [JsonPropertyName("login_url")]
        public string LoginUrl { get; set; }
    }
}
