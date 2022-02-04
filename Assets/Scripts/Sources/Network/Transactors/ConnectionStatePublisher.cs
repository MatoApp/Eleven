using System;
using UniRx;
using Zenject;
using MatoApp.Utilities;

namespace MatoApp.Eleven.Network
{
    /// <summary>
    /// Networkへの接続状態を公開するクラス
    /// </summary>
    internal class ConnectionStatePublisher : IConnectionStatePublisher
    {
        public IConnectionService ConnectionService { private get; init; }

        public ConnectionStatePublisher() { }
        [Inject]
        public ConnectionStatePublisher(
            [Inject] IConnectionService connectionService)
        {
            ConnectionService = connectionService;
        }

        public IObservable<Unit> OnConnected => ConnectionService.OnConnected;
        public IObservable<DisconnectCause> OnDisconnected => ConnectionService.OnDisconnected;
    }
}
