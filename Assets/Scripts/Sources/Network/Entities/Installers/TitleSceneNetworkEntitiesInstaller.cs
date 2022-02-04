using Zenject;
using MatoApp.Utilities;

namespace MatoApp.Eleven.Network
{
    /// <summary>
    /// TitleSceneのNetworkEntityを各オブジェクトにInstallするクラス
    /// </summary>
    internal class TitleSceneNetworkEntitiesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<ConnectionService>()
                .AsSingle();

            Container
                .BindInterfacesTo<UserInfoRepository>()
                .AsSingle();
        }
    }
}
