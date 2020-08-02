using System.Net.Http;
using System.Threading.Tasks;
using GraphApi.Facebook.Client.Constants;
using GraphApi.Facebook.Client.GraphApi.AccessToken.Models;

namespace GraphApi.Facebook.Client.GraphApi.AccessToken
{
    public interface IAccessTokenFbService {
        Task<UserAccessTokenResult> GetLongLivedUserAccessToken(string userAccessToken);
        Task<UserAccessTokenResult> GetSessionInfoToken(string longLivedUserToken);
    }

    internal class AccessTokenFbService : IAccessTokenFbService
    {
        private readonly IFacebookClient facebookClient;

        public AccessTokenFbService(IFacebookClient facebookClient)
        {
            this.facebookClient = facebookClient;
        }
        public async Task<UserAccessTokenResult> GetLongLivedUserAccessToken(string userAccessToken)
        {
            return await facebookClient.SendRequestAsync<UserAccessTokenResult>(
                GetAccessTokenRequest(FacebookGrantType.ExchangeToken, userAccessToken));
        }

        public async Task<UserAccessTokenResult> GetSessionInfoToken(string longLivedUserToken)
        {
            return await facebookClient.SendRequestAsync<UserAccessTokenResult>(
                GetAccessTokenRequest(FacebookGrantType.SessionInfoToken, longLivedUserToken));
        }

        private HttpRequestMessage GetAccessTokenRequest(string grantType, string exchangeToken)
        {
            var url = FacebookUrl.GetUrl(FacebookUrl.TokenUrl, FacebookApiVersion.Version5);

            return GraphApiRequestBuilder
                .BuildRequestTo(url)
                .WithMethod(HttpMethod.Get)
                .WithUrlPatameter("fb_exchange_token", exchangeToken)
                .WithUrlPatameter("grant_type", grantType)
                .WithClientIdAndClientSecret((facebookClient.AppId, facebookClient.AppSecret))
                .GetHttpRequestMessage();
        }
    }
}
