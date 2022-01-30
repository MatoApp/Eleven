using System;
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
        private Subject<Scene> OnSceneLoadedSubject { get; } = new();

        public IObservable<Scene> OnSceneLoaded => OnSceneLoadedSubject.AsObservable();

        public async void LoadScene(Scene scene)
        {
            await SceneManager.LoadSceneAsync(scene.GetName()).ToUniTask();
            OnSceneLoadedSubject.OnNext(scene);
        }
    }
}
