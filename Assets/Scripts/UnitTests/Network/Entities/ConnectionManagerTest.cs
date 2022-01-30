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
    internal class ConnectionManagerTest
    {
        private ConnectionManager ConnectionManager { get; set; }

        [OneTimeSetUp]
        public void Initialize() { }

        [SetUp]
        public void SetUp()
        {
            ConnectionManager = new();
        }

        [UnityTest]
        public IEnumerator _01_Connectが呼ばれたらNetworkに接続後OnConnectedを発行する() => UniTask.ToCoroutine(async () =>
        {
            ConnectionManager.Initialize();

            var cts = new CancellationTokenSource();
            cts.CancelAfterSlim(TimeSpan.FromSeconds(5));

            ConnectionManager.Connect();

            await ConnectionManager.OnConnected.ToUniTask(useFirstValue: true, cancellationToken: cts.Token);

            Assert.AreEqual(true, true);
        });

        [UnityTest]
        public IEnumerator _02_Disconnectが呼ばれたらNetworkを切断後OnDisconnectedを発行する() => UniTask.ToCoroutine(async () =>
        {
            ConnectionManager.Initialize();

            var cts = new CancellationTokenSource();
            cts.CancelAfterSlim(TimeSpan.FromSeconds(5));

            ConnectionManager.Disconnect();

            await ConnectionManager.OnDisconnected.ToUniTask(useFirstValue: true, cancellationToken: cts.Token);

            Assert.AreEqual(true, true);
        });
    }
}