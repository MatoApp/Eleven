using Zenject;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MatoApp.Utilities;

namespace MatoApp.Eleven.View
{
    /// <summary>
    /// TitleSceneのViewEntityを各オブジェクトにInstallするクラス
    /// </summary>
    internal class TitleSceneViewEntitiesInstaller : MonoInstaller
    {
        [SerializeField]
        private Button SigninButton { get; init; }
        [SerializeField]
        private TMP_InputField UsernameInputField { get; init; }

        public override void InstallBindings()
        {
            Container
                .BindInstance(SigninButton)
                .WithId(TitleSceneViewEntity.SigninButton);

            Container
                .BindInstance(UsernameInputField)
                .WithId(TitleSceneViewEntity.UsernameInputField);

            Container
                .BindInterfacesTo<SceneLoader>()
                .AsSingle();
        }
    }
}
