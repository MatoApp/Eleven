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
        public IConnectionManager ConnectionManager { private get; init; }

        public ConnectionStatePublisher() { }
        [Inject]
        public ConnectionStatePublisher(
            [Inject] IConnectionManager connectionManager)
        {
            ConnectionManager = connectionManager;
        }

        public IObservable<Unit> OnConnected => ConnectionManager.OnConnected;
        public IObservable<string> OnDisconnected => ConnectionManager.OnDisconnected;
    }
}
