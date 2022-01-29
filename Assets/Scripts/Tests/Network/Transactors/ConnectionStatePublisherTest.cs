using NUnit.Framework;
using NSubstitute;
using MatoApp.Utilities;
using Assert = UnityEngine.Assertions.Assert;

namespace MatoApp.Eleven.Network.Tests
{
    internal class ConnectionStatePublisherTest
    {
        private ConnectionStatePublisher ConnectionStatePublisher { get; set; }

        private IConnectionManager ConnectionManager { get; set; }

        [OneTimeSetUp]
        public void Initialize() { }

        [SetUp]
        public void SetUp()
        {
            ConnectionManager = Substitute.For<IConnectionManager>();

            ConnectionStatePublisher = new()
            {
                ConnectionManager = ConnectionManager,
            };
        }

        [Test]
        public void _01_OnConnectedがgetされたらConnectionManagerのOnConnectedをgetする()
        {
            _ = ConnectionStatePublisher.OnConnected;

            _ = ConnectionManager.Received().OnConnected;
        }

        [Test]
        public void _02_OnDisconnectedがgetされたらConnectionManagerのOnDisconnectedをgetする()
        {
            _ = ConnectionStatePublisher.OnDisconnected;

            _ = ConnectionManager.Received().OnDisconnected;
        }
    }
}
