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
        private TMP_InputField UsernameInputField { get; set; }
        private Button SigninButton { get; set; }

        [OneTimeSetUp]
        public void Initialize() { }

        [SetUp]
        public void SetUp()
        {
            SigninSupplier = Substitute.For<ISigninSupplier>();
            UsernameInputField = new GameObject().AddComponent<TMP_InputField>();
            SigninButton = new GameObject().AddComponent<Button>();

            SigninRequester = new()
            {
                SigninSupplier = SigninSupplier,
                UsernameInputField = UsernameInputField,
                SigninButton = SigninButton
            };
        }

        [Test]
        public void _01_Usernameが入力されている状態でSigninButtonが押されたらSigninをRequestする()
        {
            SigninRequester.Initialize();

            UsernameInputField.text = "username";
            SigninButton.onClick.Invoke();

            SigninSupplier.Received().SetUsername("username");
            SigninSupplier.Received().Signin();
        }

        [Test]
        public void _02_Usernameが空の状態でSigninButtonが押されたらSigninをRequestしない()
        {
            SigninRequester.Initialize();

            UsernameInputField.text = "";
            SigninButton.onClick.Invoke();

            SigninSupplier.DidNotReceiveWithAnyArgs().SetUsername(default);
            SigninSupplier.DidNotReceive().Signin();
        }
    }
}
