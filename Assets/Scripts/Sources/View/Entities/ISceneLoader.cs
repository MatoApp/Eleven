using Cysharp.Threading.Tasks;

namespace MatoApp.Eleven.View
{
    public interface ISceneLoader
    {
        UniTask LoadScene(Scene scene);
    }
}
