using Zenject;

public class FarmInstaler : MonoInstaller
{
    public override void InstallBindings()
    {
        UnityEngine.Debug.Log($"{GetType().Name} - {nameof(InstallBindings)}");
    }
}
