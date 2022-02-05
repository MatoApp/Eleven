using NUnit.Framework;
using NSubstitute;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MatoApp.Eleven.Network;
using MatoApp.Utilities;
using Assert = UnityEngine.Assertions.Assert;

namespace MatoApp.Eleven.View.Tests
{
    internal class SigninRequesterTest
    {
        private SigninRequester SigninRequester { get; set; }

        private ISigninSupplier SigninSupplier { get; set; }
        private Button SigninButton { get; set; }
        private TMP_InputField UsernameInputField { get; set; }

        [OneTimeSetUp]
        public void Initialize() { }

        [SetUp]
        public void SetUp()
        {
            SigninSupplier = Substitute.For<ISigninSupplier>();
            SigninButton = new GameObject().AddComponent<Button>();
            UsernameInputField = new GameObject().AddComponent<TMP_InputField>();         

            SigninRequester = new()
            {
                SigninSupplier = SigninSupplier,
                SigninButton = SigninButton,
                UsernameInputField = UsernameInputField,
            };
        }

        [Test]
        public void _01_Usernameが入力されている状態でSigninButtonが押されたらSigninをRequestする()
        {
            SigninRequester.Initialize();

            UsernameInputField.text = "username";
            SigninButton.onClick.Invoke();

            SigninSupplier.Received().Signin("username");
        }

        [Test]
        public void _02_Usernameが空の状態でSigninButtonが押されたらSigninをRequestしない()
        {
            SigninRequester.Initialize();

            UsernameInputField.text = "";
            SigninButton.onClick.Invoke();

            SigninSupplier.DidNotReceiveWithAnyArgs().Signin(default);
        }
    }
}
