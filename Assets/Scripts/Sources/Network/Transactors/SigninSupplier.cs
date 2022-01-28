using UniRx;
using Zenject;
using MatoApp.Utilities;

namespace MatoApp.Eleven.Network
{
    /// <summary>
    /// Signinに必要なメソッドを提供するクラス
    /// </summary>
    internal class SigninSupplier : ISigninSupplier
    {
        public IConnectionManager ConnectionManager { private get; init; }
        public IUserInfoRepository UserInfoRepository { private get; init; }

        public SigninSupplier() { }
        [Inject]
        public SigninSupplier(
            [Inject] IConnectionManager connectionManager,
            [Inject] IUserInfoRepository userInfoRepository)
        {
            ConnectionManager = connectionManager;
            UserInfoRepository = userInfoRepository;
        }

        public void Signin()
        {
            ConnectionManager.Connect();
        }

        public void SetUsername(string username)
        {
            UserInfoRepository.Username = username;
        }
    }
}
