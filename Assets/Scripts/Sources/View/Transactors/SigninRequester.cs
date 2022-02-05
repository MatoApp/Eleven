using UniRx;
using Zenject;
using UnityEngine.UI;
using TMPro;
using MatoApp.Eleven.Network;
using MatoApp.Utilities;

namespace MatoApp.Eleven.View
{
    /// <summary>
    /// Usernameが入力されている状態でSigninButtonが押されたらSigninをRequestするクラス
    /// </summary>
    internal class SigninRequester : IInitializable
    {
        public ISigninSupplier SigninSupplier { private get; init; }

        public Button SigninButton { private get; init; }
        public TMP_InputField UsernameInputField { private get; init; } 

        public SigninRequester() { }
        [Inject]
        public SigninRequester(
            [Inject] ISigninSupplier signinSupplier,
            [Inject(Id = TitleSceneViewEntity.SigninButton)] Button signinButton,
            [Inject(Id = TitleSceneViewEntity.UsernameInputField)] TMP_InputField usernameInputField)
        {
            SigninSupplier = signinSupplier;
            SigninButton = signinButton;
            UsernameInputField = usernameInputField;        
        }

        public void Initialize()
        {
            SigninButton
                .onClick
                .AsObservable()
                .Where(_ => UsernameInputField.text != string.Empty)
                .Subscribe(_ =>
                {
                    SigninSupplier.Signin(username: UsernameInputField.text);
                });
        }
    }
}

