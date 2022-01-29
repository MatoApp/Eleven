using NUnit.Framework;
using NSubstitute;
using MatoApp.Utilities;
using Assert = UnityEngine.Assertions.Assert;

namespace MatoApp.Eleven.Network.Tests
{
    internal class SigninSupplierTest
    {
        private SigninSupplier SigninSupplier { get; set; }

        private IConnectionManager ConnectionManager { get; set; }
        private IUserInfoRepository UserInfoRepository { get; set; }

        [OneTimeSetUp]
        public void Initialize() { }

        [SetUp]
        public void SetUp()
        {
            ConnectionManager = Substitute.For<IConnectionManager>();
            UserInfoRepository = Substitute.For<IUserInfoRepository>();

            SigninSupplier = new()
            {
                ConnectionManager = ConnectionManager,
                UserInfoRepository = UserInfoRepository
            };
        }

        [Test]
        public void _01_Signinが呼ばれたらConnectionManagerのConnectを実行する()
        {
            SigninSupplier.Signin();

            ConnectionManager.Received().Connect();
        }

        [Test]
        public void _02_SetUsernameが呼ばれたらUserInfoRepositoryのUsernameにsetする()
        {
            SigninSupplier.SetUsername("username");

            UserInfoRepository.Received().Username = "username";
        }
    }
}
