using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MatoApp.Utilities;
using Assert = UnityEngine.Assertions.Assert;

namespace MatoApp.Eleven.View.Tests
{
    internal class SigninButtonInteractiveStateSwitcherTest
    {
        private SigninButtonInteractiveStateSwitcher SigninButtonInteractiveStateSwitcher { get; set; }

        private Button SigninButton { get; set; }
        private TMP_InputField UsernameInputField { get; set; }

        [OneTimeSetUp]
        public void Initialize() { }

        [SetUp]
        public void SetUp()
        {
            SigninButton = new GameObject()
                .AddComponent<Button>();
            UsernameInputField = new GameObject()
                .AddComponent<TMP_InputField>();

            SigninButtonInteractiveStateSwitcher = new()
            {
                SigninButton = SigninButton,
                UsernameInputField = UsernameInputField,
            };
        }

        [Test]
        public void _01_Usernameが入力されていたらSigninButtonが有効になる()
        {
            SigninButtonInteractiveStateSwitcher.Initialize();

            UsernameInputField.text = "username";
            Assert.AreEqual(true, SigninButton.interactable);
        }

        [Test]
        public void _02_Usernameが入力されていなかったらSigninButtonが無効になる()
        {
            SigninButtonInteractiveStateSwitcher.Initialize();

            UsernameInputField.text = "";
            Assert.AreEqual(false, SigninButton.interactable);
        }
    }
}
