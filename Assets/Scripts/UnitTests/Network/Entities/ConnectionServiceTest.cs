using NUnit.Framework;
using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Threading;
using UniRx;
using UnityEngine.TestTools;
using MatoApp.Utilities;
using Assert = UnityEngine.Assertions.Assert;

namespace MatoApp.Eleven.Network.Tests
{
    internal class ConnectionServiceTest
    {
        private ConnectionService ConnectionService { get; set; }

        [OneTimeSetUp]
        public void Initialize() { }

        [SetUp]
        public void SetUp()
        {
            ConnectionService = new();
        }

        [UnityTest]
        public IEnumerator _01_Connectが呼ばれたらNetworkに接続後OnConnectedを発行する() => UniTask.ToCoroutine(async () =>
        {
            ConnectionService.Initialize();

            ConnectionService.Connect();

            var cts = new CancellationTokenSource();
            cts.CancelAfterSlim(TimeSpan.FromSeconds(5));
            await ConnectionService.OnConnected.ToUniTask(useFirstValue: true, cancellationToken: cts.Token);

            Assert.AreEqual(true, true);
        });

        [UnityTest]
        public IEnumerator _02_Disconnectが呼ばれたらNetworkを切断後OnDisconnectedを発行する() => UniTask.ToCoroutine(async () =>
        {
            ConnectionService.Initialize();

            ConnectionService.Disconnect();

            var cts = new CancellationTokenSource();
            cts.CancelAfterSlim(TimeSpan.FromSeconds(5));
            await ConnectionService.OnDisconnected.ToUniTask(useFirstValue: true, cancellationToken: cts.Token);

            Assert.AreEqual(true, true);
        });
    }
}