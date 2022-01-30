using NUnit.Framework;
using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Threading;
using UniRx;
using UnityEngine.TestTools;
using MatoApp.Utilities;
using Assert = UnityEngine.Assertions.Assert;

namespace MatoApp.Eleven.View.Tests
{
    internal class SceneLoaderTest
    {
        private SceneLoader SceneLoader { get; set; }

        [OneTimeSetUp]
        public void Initialize() { }

        [SetUp]
        public void SetUp()
        {
            SceneLoader = new();
        }

        [UnityTest]
        public IEnumerator _01_LoadSceneが呼ばれたらSceneManagementのLoadSceneAsyncを実行する() => UniTask.ToCoroutine(async () =>
        {
            var cts = new CancellationTokenSource();
            cts.CancelAfterSlim(TimeSpan.FromSeconds(5));

            SceneLoader.LoadScene(Scene.Lobby);

            await SceneLoader.OnSceneLoaded.ToUniTask(useFirstValue: true, cancellationToken: cts.Token);

            Assert.AreEqual(true, true);
        });
    }
}