using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GraphApi.Facebook.Client;
using GraphApi.Facebook.Client.Constants;
using GraphApi.Facebook.Client.GraphApi;
using GraphApi.Facebook.GraphApi.TestUser.Models;

namespace GraphApi.Facebook.GraphApi.TestUser
{
    public interface ITestUserFbService
    {
        Task<IEnumerable<TestUserResult>> GetTestUsers();
    }

    internal class TestUserFbService : ITestUserFbService
    {
        private readonly IFacebookClient facebookClient;

        public TestUserFbService(IFacebookClient facebookClient)
        {
            this.facebookClient = facebookClient;
        }
        public async Task<IEnumerable<TestUserResult>> GetTestUsers()
        {
            var url = FacebookUrl.GetUrl(FacebookUrl.TestUserUrl, FacebookApiVersion.Version5, this.facebookClient.AppId);

            var request = GraphApiRequestBuilder
                .BuildRequestTo(url)
                .WithMethod(HttpMethod.Get)
                .WithAccessToken(await facebookClient.GetApplicationAccessTokenAsync())
                .GetHttpRequestMessage();
            return (await facebookClient.SendRequestAsync<DataWrapper<IEnumerable<TestUserResult>>>(request)).Data;
        }
    }
}
