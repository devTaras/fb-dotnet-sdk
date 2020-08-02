using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using GraphApi.Facebook.Client.GraphApi.User;
using GraphApi.Facebook.GraphApi.TestUser;
using GraphApi.Facebook.GraphApi.User.Models.Request;

namespace GraphApi.Facebook.Client.Tests
{
    [TestClass]
    public class UsersIntegrationTests
    {
        private static ServiceProvider sp;
        private static string testUserToken;

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            sp = TestServiceProvider.ServiceProvider;
            testUserToken = TestServiceProvider.TestUserAccessToken;
        }

        [TestMethod]
        public async Task GetTestUsers_ReturnResult()
        {
            var testUser = sp.GetService(typeof(ITestUserFbService)) as ITestUserFbService;
            var result = await testUser.GetTestUsers();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetUser_ReturnResult()
        {
            var userApi = sp.GetService(typeof(IUserFbService)) as IUserFbService;
            var result = await userApi.GetUserAsync(testUserToken);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetUserPicture_DefaultOptions_ReturnResult()
        {
            var userApi = sp.GetService(typeof(IUserFbService)) as IUserFbService;
            var result = await userApi.GetProfilePictureAsync(testUserToken);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetUserPicture_CustomOptions_ReturnResult()
        {
            var userApi = sp.GetService(typeof(IUserFbService)) as IUserFbService;
            var result = await userApi.GetProfilePictureAsync(testUserToken, profilePictureOptions: new UserProfilePictureOptions { Type= PictureSizeType.Square });
            Assert.IsNotNull(result);
        }
    }
}
