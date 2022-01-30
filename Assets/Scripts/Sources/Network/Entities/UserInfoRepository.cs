using Photon.Pun;
using MatoApp.Utilities;

namespace MatoApp.Eleven.Network
{
    /// <summary>
    /// Network上のユーザー情報を保管するクラス
    /// </summary>
    internal class UserInfoRepository : IUserInfoRepository
    {
        public string Username
        {
            get => PhotonNetwork.NickName;
            set => PhotonNetwork.NickName = value;
        }
    }
}
