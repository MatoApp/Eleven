using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MatoApp.Utilities;
using Assert = UnityEngine.Assertions.Assert;

namespace MatoApp.Eleven.View.Tests
{
    internal class SigninButtonActiveStateSwitcherTest
    {
        private SigninButtonActiveStateSwitcher SigninButtonActiveStateSwitcher { get; set; }

        private TMP_InputField UsernameInputField { get; set; }
        private Button SigninButton { get; set; }

        [OneTimeSetUp]
        public void Initialize() { }

        [SetUp]
        public void SetUp()
        {
            UsernameInputField = new GameObject()
                .AddComponent<TMP_InputField>();
            SigninButton = new GameObject()
                .AddComponent<Button>();

            SigninButtonActiveStateSwitcher = new()
            {
                UsernameInputField = UsernameInputField,
                SigninButton = SigninButton,
            };
        }

        [Test]
        public void _01_Usernameが入力されていたらSigninButtonが有効になる()
        {
            SigninButtonActiveStateSwitcher.Initialize();

            UsernameInputField.onValueChanged.Invoke("username");
            Assert.AreEqual(true, SigninButton.interactable);
        }

        [Test]
        public void _02_Usernameが入力されていなかったらSigninButtonが無効になる()
        {
            SigninButtonActiveStateSwitcher.Initialize();

            UsernameInputField.onValueChanged.Invoke("");
            Assert.AreEqual(false, SigninButton.interactable);
        }
    }
}
