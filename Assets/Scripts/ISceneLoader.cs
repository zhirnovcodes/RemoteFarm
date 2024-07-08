using Cysharp.Threading.Tasks;

public interface ISceneLoader
{
    UniTask LoadInit();
    UniTask LoadFarm();
}
