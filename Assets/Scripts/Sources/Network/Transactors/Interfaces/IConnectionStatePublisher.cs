using System;
using UniRx;

namespace MatoApp.Eleven.Network
{
    public interface IConnectionStatePublisher
    {
        IObservable<Unit> OnConnected { get; }
        IObservable<DisconnectCause> OnDisconnected { get; }
    }
}