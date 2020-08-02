using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using GraphApi.Facebook.Client.Config;

namespace GraphApi.Facebook.Client
{
    internal interface IFacebookClient
    {
        string AppId { get; }
        string AppSecret { get; }
        Task<T> SendRequestAsync<T>(HttpRequestMessage httpRequestMessage);
        Task<string> GetApplicationAccessTokenAsync();
    }
    internal class FacebookClient : IFacebookClient
    {
        private readonly HttpClient facebookHttpClient;
        private readonly ApplicationCredentials applicationCredentials;

        public string AppId => applicationCredentials.AppId;

        public string AppSecret => applicationCredentials.Secret;

        public FacebookClient(IHttpClientFactory clientFactory, IOptions<ApplicationCredentials> options)
        {
            this.facebookHttpClient = clientFactory.CreateClient(Facebook.Constants.Facebook.FacebookClientName);
            this.applicationCredentials = options.Value;
        }

        public async Task<T> SendRequestAsync<T>(HttpRequestMessage httpRequestMessage)
        {
            var response = await this.facebookHttpClient.SendAsync(httpRequestMessage);
            response.EnsureSuccessStatusCode();
            var result =  await JsonSerializer
                .DeserializeAsync<T>(await response.Content.ReadAsStreamAsync());
            return result;
        }

        public Task<string> GetApplicationAccessTokenAsync()
        {
            return Task.FromResult($"{applicationCredentials.AppId}|{applicationCredentials.Secret}");
        }
    }
}
