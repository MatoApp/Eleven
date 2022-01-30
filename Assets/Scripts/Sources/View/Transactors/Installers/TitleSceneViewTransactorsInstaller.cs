using Zenject;
using MatoApp.Utilities;

namespace MatoApp.Eleven.View
{
    /// <summary>
    /// TitleSceneのViewTransactorを各オブジェクトにInstallするクラス
    /// </summary>
    internal class TitleSceneViewTransactorsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<SigninRequester>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<ConnectionStateObserver>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<SigninButtonInteractiveStateSwitcher>()
                .AsSingle()
                .NonLazy();
        }
    }
}
