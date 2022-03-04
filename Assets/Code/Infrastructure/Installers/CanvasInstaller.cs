using UnityEngine;
using Zenject;

public class CanvasInstaller : MonoInstaller
{
    public Canvas CanvasPrefab;
    
    public override void InstallBindings()
    {
        BindCanvas();
    }

    private void BindCanvas()
    {
        Canvas canvas = Container.InstantiatePrefabForComponent<Canvas>(CanvasPrefab, 
            Vector3.zero, Quaternion.identity, null);

        Container.Bind<Canvas>().FromInstance(canvas).AsSingle();
    }
}