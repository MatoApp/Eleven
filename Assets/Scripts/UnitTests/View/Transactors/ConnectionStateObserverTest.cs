using NUnit.Framework;
using NSubstitute;
using UniRx;
using MatoApp.Eleven.Network;
using MatoApp.Utilities;
using Assert = UnityEngine.Assertions.Assert;

namespace MatoApp.Eleven.View.Tests
{
    internal class ConnectionStateObserverTest
    {
        private ConnectionStateObserver ConnectionStateObserver { get; set; }

        private IConnectionStatePublisher ConnectionStatePublisher { get; set; }
        private ISceneLoader SceneLoader { get; set; }

        private Subject<Unit> OnConnectedSubject { get; set; }

        [OneTimeSetUp]
        public void Initialize() { }

        [SetUp]
        public void SetUp()
        {
            ConnectionStatePublisher = Substitute.For<IConnectionStatePublisher>();
            SceneLoader = Substitute.For<ISceneLoader>();

            OnConnectedSubject = new();
            ConnectionStatePublisher.OnConnected.Returns(OnConnectedSubject.AsObservable());

            ConnectionStateObserver = new()
            {
                ConnectionStatePublisher = ConnectionStatePublisher,
                SceneLoader = SceneLoader
            };
        }

        [Test]
        public void _01_Connectionが確立されたらLobbySceneをLoadする()
        {
            ConnectionStateObserver.Initialize();

            OnConnectedSubject.OnNext(default);

            SceneLoader.Received().LoadScene(Scene.Lobby);
        }
    }
}
