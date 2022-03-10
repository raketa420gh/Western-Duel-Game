using Raketa420;
using Zenject;

public class CountdownInstaller : MonoInstaller
{
    public Countdown Countdown;

    public override void InstallBindings()
    {
        BindCountdown();
    }
    
    private void BindCountdown()
    {
        Container.Bind<ICountdownService>().To<Countdown>().FromComponentInNewPrefab(Countdown).AsSingle().NonLazy();
    }
}