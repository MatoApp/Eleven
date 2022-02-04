using NUnit.Framework;
using NSubstitute;
using MatoApp.Utilities;
using Assert = UnityEngine.Assertions.Assert;

namespace MatoApp.Eleven.Network.Tests
{
    internal class ConnectionStatePublisherTest
    {
        private ConnectionStatePublisher ConnectionStatePublisher { get; set; }

        private IConnectionService ConnectionService { get; set; }

        [OneTimeSetUp]
        public void Initialize() { }

        [SetUp]
        public void SetUp()
        {
            ConnectionService = Substitute.For<IConnectionService> ();

            ConnectionStatePublisher = new()
            {
                ConnectionService = ConnectionService,
            };
        }

        [Test]
        public void _01_OnConnectedがgetされたらConnectionManagerのOnConnectedをgetする()
        {
            _ = ConnectionStatePublisher.OnConnected;

            _ = ConnectionService.Received().OnConnected;
        }

        [Test]
        public void _02_OnDisconnectedがgetされたらConnectionManagerのOnDisconnectedをgetする()
        {
            _ = ConnectionStatePublisher.OnDisconnected;

            _ = ConnectionService.Received().OnDisconnected;
        }
    }
}
