using System;

namespace MatoApp.Eleven.View
{
    public interface ISceneLoader
    {
        void LoadScene(Scene scene);

        IObservable<Scene> OnSceneLoaded { get; }
    }
}
