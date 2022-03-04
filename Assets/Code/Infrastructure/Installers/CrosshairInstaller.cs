using Raketa420;
using UnityEngine;
using Zenject;

public class CrosshairInstaller : MonoInstaller
{
    public Crosshair CrosshairPrefab;
    
    public override void InstallBindings()
    {
        BindCrosshair();
    }
    
    private void BindCrosshair()
    {
        Crosshair crosshair = Container.InstantiatePrefabForComponent<Crosshair>(CrosshairPrefab,
            Vector3.zero, Quaternion.identity, null);

        crosshair.gameObject.transform.localPosition = new Vector3(0, 0, 0);
        
        Container.Bind<Crosshair>().FromInstance(crosshair).AsSingle();
    }
}