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
        public IConnectionService ConnectionService { private get; init; }
        public IUserInfoRepository UserInfoRepository { private get; init; }

        public SigninSupplier() { }
        [Inject]
        public SigninSupplier(
            [Inject] IConnectionService connectionService,
            [Inject] IUserInfoRepository userInfoRepository)
        {
            ConnectionService = connectionService;
            UserInfoRepository = userInfoRepository;
        }

        public void Signin()
        {
            ConnectionService.Connect();
        }

        public void SetUsername(string username)
        {
            UserInfoRepository.Username = username;
        }
    }
}
