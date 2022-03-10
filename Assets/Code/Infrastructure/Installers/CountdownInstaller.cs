using Raketa420;
using Zenject;

public class CountdownInstaller : MonoInstaller
{
    public Countdown Countdown;
    
    public override void InstallBindings()
    {
        BindCountdownService();
    }
    
    private void BindCountdownService()
    {
        Container.Bind<ICountdownService>().To<Countdown>().FromComponentInNewPrefab(Countdown).AsSingle();
    }
}