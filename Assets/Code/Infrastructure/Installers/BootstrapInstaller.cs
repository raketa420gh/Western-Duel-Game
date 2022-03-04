using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    public AssetProvider AssetProvider;
    public GameFactory GameFactory;
    public SceneLoader SceneLoader;
    public MobileInputService InputService;
    
    public override void InstallBindings()
    {
        BindAssetProvider();
        BindFactory();
        BindSceneLoader();
        BindInputService();
    }

    private void BindAssetProvider()
    {
        Container.Bind<IAssetProvider>().To<AssetProvider>().FromComponentInNewPrefab(AssetProvider).AsSingle();
    }

    private void BindFactory()
    {
        Container.Bind<IGameFactory>().To<GameFactory>().FromComponentInNewPrefab(GameFactory).AsSingle();
    }

    private void BindSceneLoader()
    {
        Container.Bind<SceneLoader>().FromComponentInNewPrefab(SceneLoader).AsSingle();
    }

    private void BindInputService()
    {
        Container.Bind<IInputService>().To<MobileInputService>().FromComponentInNewPrefab(InputService).AsSingle();
    }
}