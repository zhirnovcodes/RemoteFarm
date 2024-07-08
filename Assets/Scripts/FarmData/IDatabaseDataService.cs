using Cysharp.Threading.Tasks;

public interface IDatabaseDataService
{
    UniTask<bool> Load();
    IDatabaseDataModel CurrentModel { get; }
}
