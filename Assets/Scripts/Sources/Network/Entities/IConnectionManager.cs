using System;
using UniRx;

namespace MatoApp.Eleven.Network
{
    public interface IConnectionManager
    {
        void Connect();
        void Disconnect();

        IObservable<Unit> OnConnected { get; }
        IObservable<string> OnDisconnected { get; }
    }
}