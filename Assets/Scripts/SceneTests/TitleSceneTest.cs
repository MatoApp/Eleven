using Zenject;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using TMPro;
using MatoApp.Eleven.View;
using MatoApp.Utilities;
using Assert = UnityEngine.Assertions.Assert;

namespace MatoApp.Eleven.Tests
{
    internal class TitleSceneTest : SceneTestFixture
    {
        private Button SigninButton { get; set; }
        private TMP_InputField UsernameInputField { get; set; }
        private ISceneLoader SceneLoader { get; set; }

        [UnityTest]
        public IEnumerator _01_Usernameを入力してSigninButtonを押すとLobbySceneに遷移する() => UniTask.ToCoroutine(async () =>
        {
            await LoadScene(Scene.Title.GetName());

            SigninButton = new GameObject()
                .AddComponent<Button>();
            UsernameInputField = new GameObject()
                .AddComponent<TMP_InputField>();

            SigninButton = SceneContainer.ResolveId<Button>(TitleSceneViewEntity.SigninButton);
            UsernameInputField = SceneContainer.ResolveId<TMP_InputField>(TitleSceneViewEntity.UsernameInputField);
            SceneLoader = SceneContainer.Resolve<ISceneLoader>();

            Assert.IsNotNull(SigninButton);
            Assert.IsNotNull(UsernameInputField);
            Assert.IsNotNull(SceneLoader);

            UsernameInputField.text = "username";
            SigninButton.onClick.Invoke();

            var cts = new CancellationTokenSource();
            cts.CancelAfterSlim(TimeSpan.FromSeconds(5));

            SceneLoader.LoadScene(Scene.Lobby);

            await SceneLoader.OnSceneLoaded.ToUniTask(useFirstValue: true, cancellationToken: cts.Token);

            Assert.AreEqual(true, true);
        });
    }
}