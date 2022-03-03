using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    public MobileInputService inputService;
    
    public override void InstallBindings()
    {
        BindInputService();
    }

    private void BindInputService()
    {
        Container.Bind<IInputService>().To<MobileInputService>().FromComponentInNewPrefab(inputService).AsSingle();
    }
}