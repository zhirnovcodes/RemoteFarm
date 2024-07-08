using Cysharp.Threading.Tasks;

public interface ISceneDataService
{
    ISceneDataModel Data { get; }
    UniTask<SceneDataLoadResult> LoadPositions();
    UniTask<SceneDataLoadResult> LoadLinks();

    public class SceneDataLoadResult
    {
        public bool Success;
        public string ErrorMessage;
    }
}