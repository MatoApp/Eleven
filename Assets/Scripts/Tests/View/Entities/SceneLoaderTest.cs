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
            await SceneLoader.LoadScene(Scene.Lobby);

            Assert.AreEqual(true, true);
        });
    }
}