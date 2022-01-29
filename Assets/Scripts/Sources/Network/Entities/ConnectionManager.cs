using System;
using System.Collections.Generic;
using UniRx;
using Zenject;
using Photon.Pun;
using Photon.Realtime;
using MatoApp.Utilities;

namespace MatoApp.Eleven.Network
{
    /// <summary>
    /// Networkへの接続を管理するクラス
    /// </summary>
    internal class ConnectionManager : IConnectionManager, IConnectionCallbacks, IInitializable
    {
        private Subject<Unit> OnConnectedSubject { get; } = new();
        private Subject<string> OnDisconnectedSubject { get; } = new();

        public IObservable<Unit> OnConnected => OnConnectedSubject.AsObservable();
        public IObservable<string> OnDisconnected => OnDisconnectedSubject.AsObservable();

        public void Initialize()
        {
            PhotonNetwork.AddCallbackTarget(this);
        }

        public void Connect()
        {
            PhotonNetwork.ConnectUsingSettings();
        }
        public void Disconnect()
        {
            PhotonNetwork.Disconnect();
        }

        void IConnectionCallbacks.OnConnected() {}
        void IConnectionCallbacks.OnConnectedToMaster()
        {
            OnConnectedSubject.OnNext(Unit.Default);
        }
        void IConnectionCallbacks.OnDisconnected(DisconnectCause cause)
        {
            OnDisconnectedSubject.OnNext(cause.ToString());
        }
        void IConnectionCallbacks.OnRegionListReceived(RegionHandler regionHandler) { }
        void IConnectionCallbacks.OnCustomAuthenticationFailed(string debugMessage) { }
        void IConnectionCallbacks.OnCustomAuthenticationResponse(Dictionary<string, object> data) { }
    }
}
