namespace GraphApi.Facebook.Client.Constants
{
    internal class FacebookUrl
    {
        /// <summary>
        /// Token URL template (replace {0} with Facebook API version)
        /// </summary>
        public const string TokenUrl = "/{0}/oauth/access_token";

        /// <summary>
        /// Debug token URL template (replace {0} with Facebook API version)
        /// </summary>
        public const string DebugTokenUrl = "/{0}/debug_token";

        public const string UserUrl = "/{0}/{1}/";

        public const string UserPictureUrl = "{0}/{1}/picture";

        public const string TestUserUrl = "{0}/{1}/accounts/test-users";

        public static string GetUrl(string urlTemplate, params string[] args)
        {
            return string.Format(urlTemplate, args);
        }
    }
}
