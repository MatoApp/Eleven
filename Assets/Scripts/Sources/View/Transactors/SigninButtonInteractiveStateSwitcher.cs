using UniRx;
using Zenject;
using UnityEngine.UI;
using TMPro;
using MatoApp.Utilities;

namespace MatoApp.Eleven.View
{
    internal class SigninButtonInteractiveStateSwitcher : IInitializable
    {
        public Button SigninButton { private get; init; }
        public TMP_InputField UsernameInputField { private get; init; }

        public SigninButtonInteractiveStateSwitcher() { }
        [Inject]
        public SigninButtonInteractiveStateSwitcher(
            [Inject(Id = TitleSceneViewEntity.SigninButton)] Button signinButton,
            [Inject(Id = TitleSceneViewEntity.UsernameInputField)] TMP_InputField usernameInputField)
        {
            SigninButton = signinButton;
            UsernameInputField = usernameInputField;
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
