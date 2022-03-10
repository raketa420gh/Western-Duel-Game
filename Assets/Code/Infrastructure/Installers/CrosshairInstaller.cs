using Raketa420;
using UnityEngine;
using Zenject;

public class CrosshairInstaller : MonoInstaller
{
    private Canvas canvas;

    [Inject]
    public void Construct(Canvas canvas)
    {
        this.canvas = canvas;
    }
    
    public override void InstallBindings()
    {
        BindCrosshair();
    }
    
    private void BindCrosshair()
    {
        var crosshair = canvas.GetComponentInChildren<Crosshair>();
        crosshair.gameObject.transform.localPosition = new Vector3(0, 0, 0);

        Container.Bind<Crosshair>().FromInstance(crosshair).AsSingle();
    }
}