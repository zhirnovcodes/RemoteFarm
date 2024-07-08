using Cysharp.Threading.Tasks;

public interface IResourcesService
{
    UniTask<T> Load<T>(string path);
}
