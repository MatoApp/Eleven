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
    /// Networkへの接続を提供するクラス
    /// </summary>
    internal class ConnectionService : IConnectionService, IConnectionCallbacks, IInitializable
    {
        private Subject<Unit> OnConnectedSubject { get; } = new();
        private Subject<DisconnectCause> OnDisconnectedSubject { get; } = new();

        public IObservable<Unit> OnConnected => OnConnectedSubject.AsObservable();
        public IObservable<DisconnectCause> OnDisconnected => OnDisconnectedSubject.AsObservable();

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
        void IConnectionCallbacks.OnDisconnected(Photon.Realtime.DisconnectCause photonCause)
        {
            var cause = photonCause switch
            {
                Photon.Realtime.DisconnectCause.None => DisconnectCause.None,
                Photon.Realtime.DisconnectCause.ServerTimeout or
                Photon.Realtime.DisconnectCause.ClientTimeout => DisconnectCause.Timeout,
                _ => DisconnectCause.Exception,
            };

            OnDisconnectedSubject.OnNext(cause);
        }
        void IConnectionCallbacks.OnRegionListReceived(RegionHandler regionHandler) { }
        void IConnectionCallbacks.OnCustomAuthenticationFailed(string debugMessage) { }
        void IConnectionCallbacks.OnCustomAuthenticationResponse(Dictionary<string, object> data) { }
    }
}
