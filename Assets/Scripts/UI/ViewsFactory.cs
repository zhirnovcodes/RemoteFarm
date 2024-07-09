using Cysharp.Threading.Tasks;

public sealed class ViewsFactory
{
    private IResourcesService Resources;

    public ViewsFactory(IResourcesService resources)
    {
        Resources = resources;
    }

    public async UniTask<T> LoadView<T>(Views view)
    {
        var res = await Resources.Load<T, Views>(view);
        return res;
    }
}
