using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;
using GraphApi.Facebook.Client;
using GraphApi.Facebook.Client.GraphApi.AccessToken;
using GraphApi.Facebook.GraphApi.TestUser;

namespace GraphApi.Facebook.Client.Tests
{
    [TestClass]
    public class TestServiceProvider
    {
        public static ServiceProvider ServiceProvider { get; set; }

        public static string TestUserAccessToken { get; set; }
        public static string LongLivedAccessToken { get; set; }

        [AssemblyInitialize]
        public static async Task InitTestLibrary(TestContext testContext)
        {
            var configBuilder = new ConfigurationBuilder()
            .AddJsonFile("testsettings.json");
            var config = configBuilder.Build();

            ServiceProvider = new ServiceCollection()
            .AddFacebookClient(options => config.GetSection("Facebook").Bind(options))
            .BuildServiceProvider();

            var testUserApi = ServiceProvider.GetService<ITestUserFbService>();
            TestUserAccessToken = (await testUserApi.GetTestUsers()).First(testUser => testUser.Id == "101298791447225").AccessToken;

            var accessToken = ServiceProvider.GetService(typeof(IAccessTokenFbService)) as IAccessTokenFbService;
            LongLivedAccessToken = (await accessToken.GetLongLivedUserAccessToken(TestUserAccessToken)).AccessToken;
        }
    }
}
