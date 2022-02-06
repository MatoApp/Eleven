using NUnit.Framework;
using Assert = UnityEngine.Assertions.Assert;

namespace MatoApp.Eleven.Network.Tests
{
    internal class UserInfoRepositoryTest
    {
        private UserInfoRepository UserInfoRepository { get; set; }

        [OneTimeSetUp]
        public void Initialize() { }

        [SetUp]
        public void SetUp()
        {
            UserInfoRepository = new();
        }

        [Test]
        public void _01_Usernameにsetした値とgetした値が等しい()
        {
            UserInfoRepository.Username = "name";

            Assert.AreEqual("name", UserInfoRepository.Username);

            UserInfoRepository.Username = "username";

            Assert.AreEqual("username", UserInfoRepository.Username);
        }
    }
}