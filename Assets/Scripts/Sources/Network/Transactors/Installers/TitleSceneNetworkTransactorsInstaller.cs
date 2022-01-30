using Zenject;
using MatoApp.Utilities;

namespace MatoApp.Eleven.Network
{
    /// <summary>
    /// TitleSceneのNetworkTransactorを各オブジェクトにInstallするクラス
    /// </summary>
    internal class TitleSceneNetworkTransactorsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<SigninSupplier>()
                .AsSingle();

            Container
                .BindInterfacesTo<ConnectionStatePublisher>()
                .AsSingle();
        }
    }
}
