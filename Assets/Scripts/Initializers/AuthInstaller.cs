using Cysharp.Threading.Tasks;
using Zenject;

public class AuthInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        UnityEngine.Debug.Log($"{GetType().Name} - {nameof(InstallBindings)}");

        Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
        Container.Bind<IAuthorizationService>().To<MockAuthorizationService>().AsSingle();
        Container.Bind<IResourcesService>().To<ResourcesService>().AsSingle();
        Container.Bind<ViewsFactory>().AsSingle();

        Container.Bind<Bootstrapper>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
    }
}
