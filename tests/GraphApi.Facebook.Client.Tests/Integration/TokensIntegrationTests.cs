using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using GraphApi.Facebook.Client.GraphApi.AccessToken;
using GraphApi.Facebook.Client.GraphApi.DebugToken;

namespace GraphApi.Facebook.Client.Tests
{
    [TestClass]
    public class TokensIntegrationTests
    {
        private static ServiceProvider sp;
        private static string userAccessToken;
        private static string longLivedAccessToken;

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            sp = TestServiceProvider.ServiceProvider;
            userAccessToken = TestServiceProvider.TestUserAccessToken;
            longLivedAccessToken = TestServiceProvider.LongLivedAccessToken;
        }


        [TestMethod]
        public async Task GetLongLivedAccessToken_ValidToken_ShouldReturnToken()
        {
            var accessToken = sp.GetService(typeof(IAccessTokenFbService)) as IAccessTokenFbService;
            var result = await accessToken.GetLongLivedUserAccessToken(userAccessToken);
            Assert.IsNotNull(result?.AccessToken);
        }

        [TestMethod]
        public async Task GetSessionToken_LongLivedToken_ShouldReturnToken()
        {
            var sessionToken = sp.GetService(typeof(IAccessTokenFbService)) as IAccessTokenFbService;
            var sessionTokenResult = await sessionToken.GetSessionInfoToken(longLivedAccessToken);
            Assert.IsNotNull(sessionTokenResult?.AccessToken);
        }

        [TestMethod]
        public async Task DebugToken_ShouldReturnIsValid()
        {
            var debugToken = sp.GetService(typeof(IDebugTokenFbService)) as IDebugTokenFbService;
            var result = await debugToken.DebugTokenAsync(userAccessToken);
            Assert.IsTrue(result?.IsValid ?? false);
        }
    }
}
