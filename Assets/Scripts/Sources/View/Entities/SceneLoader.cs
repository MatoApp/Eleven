using UniRx;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace MatoApp.Eleven.View
{
    /// <summary>
    /// Sceneを非同期にLoadするクラス
    /// </summary>
    internal class SceneLoader : ISceneLoader
    {
        public async UniTask LoadScene(Scene scene)
        {
            await SceneManager.LoadSceneAsync($"{scene}Scene");
        }
    }
}
