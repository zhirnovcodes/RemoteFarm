using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

public class SceneLoader : ISceneLoader
{
    private const string InitSceneName = "Init";
    private const string FarmSceneName = "Farm";

    public async UniTask LoadFarm()
    {
        await SceneManager.LoadSceneAsync(FarmSceneName);
    }

    public async UniTask LoadInit()
    {
        await SceneManager.LoadSceneAsync(InitSceneName);
    }
}
