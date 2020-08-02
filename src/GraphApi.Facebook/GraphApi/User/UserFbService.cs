using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GraphApi.Facebook.Client.Constants;
using GraphApi.Facebook.Client.GraphApi.User.Models;
using GraphApi.Facebook.GraphApi.Helpers;
using GraphApi.Facebook.GraphApi.User.Models;
using GraphApi.Facebook.GraphApi.User.Models.Request;

namespace GraphApi.Facebook.Client.GraphApi.User
{
    public interface IUserFbService
    {
        /// <summary>
        /// Gets a User
        /// </summary>
        /// <param name="userAccessToken">User Access Token</param>
        /// <param name="id">Id of Facebook user in the app</param>
        /// <returns><see cref="UserResult"/></returns>
        Task<UserResult> GetUserAsync(string userAccessToken, string id = "me");

        Task<ProfilePictureResult> GetProfilePictureAsync(string userAccessToken, string id = "me", UserProfilePictureOptions profilePictureOptions = null);
    }

    internal class UserFbService : IUserFbService
    {
        private readonly IFacebookClient facebookClient;

        public UserFbService(IFacebookClient facebookClient)
        {
            this.facebookClient = facebookClient;
        }

        public async Task<ProfilePictureResult> GetProfilePictureAsync(string userAccessToken, string id = "me", UserProfilePictureOptions profilePictureOptions = null)
        {
            var url = FacebookUrl.GetUrl(FacebookUrl.UserPictureUrl, FacebookApiVersion.Version5, id);

            List<KeyValuePair<string, string>> options;
            if (profilePictureOptions != null)
            {
                options = ModelHelper.GetOptionsAsKeyValue(profilePictureOptions).ToList();
            }
            else
            {
                options = new List<KeyValuePair<string, string>>();
            }

            // By default the picture edge will return a picture instead of a JSON response. 
            // If you want the picture edge to return JSON that describes the image set redirect=0 when you make the request.
            options.Add(new KeyValuePair<string, string>("redirect", "0"));

            var request = GraphApiRequestBuilder
                .BuildRequestTo(url)
                .WithMethod(HttpMethod.Get)
                .WithUrlParameters(options)
                .WithUrlPatameter("fields", string.Join(",", ModelHelper.GetAllModelFields<ProfilePictureResult>()))
                .WithAccessToken(userAccessToken)
                .WithAppSecretProof(facebookClient.AppSecret, userAccessToken)
                .GetHttpRequestMessage();
            return (await facebookClient.SendRequestAsync<DataWrapper<ProfilePictureResult>>(request)).Data;
        }

        public async Task<UserResult> GetUserAsync(string userAccessToken, string id)
        {
            var url = FacebookUrl.GetUrl(FacebookUrl.UserUrl, FacebookApiVersion.Version5, id);

            var request =  GraphApiRequestBuilder
                .BuildRequestTo(url)
                .WithMethod(HttpMethod.Get)
                .WithUrlPatameter("fields", string.Join(",", ModelHelper.GetAllModelFields<UserResult>()))
                .WithAccessToken(userAccessToken)
                .WithAppSecretProof(facebookClient.AppSecret, userAccessToken)
                .GetHttpRequestMessage();
            return await facebookClient.SendRequestAsync<UserResult>(request);
        }

       
    }
}
