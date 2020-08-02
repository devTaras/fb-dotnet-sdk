using System.Net.Http;
using System.Threading.Tasks;
using GraphApi.Facebook.Client.Constants;
using GraphApi.Facebook.Client.GraphApi.DebugToken.Models;

namespace GraphApi.Facebook.Client.GraphApi.DebugToken
{
    /// <summary>
    /// This endpoint returns metadata about a given access token.
    /// This includes data such as the user for which the token was issued,
    /// whether the token is still valid, when it expires,
    /// and what permissions the app has for the given user.
    /// </summary>
    public interface IDebugTokenFbService
    {
        Task<DebugTokenResult> DebugTokenAsync(string inputToken);
    }

    /// <summary>
    /// <inheritdoc />
    /// </summary>
    internal class DebugTokenFbService : IDebugTokenFbService
    {
        private readonly IFacebookClient facebookClient;
        private string facebookApiVersion = FacebookApiVersion.Version5;

        public DebugTokenFbService(IFacebookClient facebookClient)
        {
            this.facebookClient = facebookClient;
        }

        public async Task<DebugTokenResult> DebugTokenAsync(string inputToken)
        {
            var debugTokenUrl = FacebookUrl.GetUrl(FacebookUrl.DebugTokenUrl, facebookApiVersion);

            return (await facebookClient.SendRequestAsync<DataWrapper<DebugTokenResult>>(
                GraphApiRequestBuilder
                .BuildRequestTo(debugTokenUrl)
                .WithMethod(HttpMethod.Get)
                .WithUrlPatameter("input_token", inputToken)
                .WithAccessToken(await facebookClient.GetApplicationAccessTokenAsync())
                .GetHttpRequestMessage())).Data;
        }
    }
}
