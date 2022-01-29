using UniRx;
using Zenject;
using UnityEngine.UI;
using TMPro;
using MatoApp.Utilities;

namespace MatoApp.Eleven.View
{
    internal class SigninButtonActiveStateSwitcher : IInitializable
    {
        public TMP_InputField UsernameInputField { private get; init; }
        public Button SigninButton { private get; init; }

        public SigninButtonActiveStateSwitcher() { }
        [Inject]
        public SigninButtonActiveStateSwitcher(
            [Inject(Id = TitleSceneViewEntity.UsernameInputField)] TMP_InputField usernameInputField,
            [Inject(Id = TitleSceneViewEntity.SigninButton)] Button signinButton)
        {
            UsernameInputField = usernameInputField;
            SigninButton = signinButton;
        }

        public void Initialize()
        {
            UsernameInputField
                .onValueChanged
                .AsObservable()
                .StartWith(UsernameInputField.text)
                .Subscribe(username => SigninButton.interactable = username != string.Empty);
        }
    }
}
