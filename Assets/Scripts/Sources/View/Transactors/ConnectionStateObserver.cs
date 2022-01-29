using UniRx;
using Zenject;
using MatoApp.Eleven.Network;
using MatoApp.Utilities;

namespace MatoApp.Eleven.View
{
    /// <summary>
    /// Connectionが確立されたらLobbySceneに遷移するクラス
    /// </summary>
    internal class ConnectionStateObserver : IInitializable
    {
        public IConnectionStatePublisher ConnectionStatePublisher { private get; init; }
        public ISceneLoader SceneLoader { private get; init; }

        public ConnectionStateObserver() { }
        [Inject]
        public ConnectionStateObserver(
            [Inject] IConnectionStatePublisher connectionStatePublisher,
            [Inject] ISceneLoader sceneLoader)
        {
            ConnectionStatePublisher = connectionStatePublisher;
            SceneLoader = sceneLoader;
        }

        public void Initialize()
        {
            ConnectionStatePublisher
                .OnConnected
                .Subscribe(async _ =>
                {
                    await SceneLoader.LoadScene(Scene.Lobby);
                });
        }
    }
}
