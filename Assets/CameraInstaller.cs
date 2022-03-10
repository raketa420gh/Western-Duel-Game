using UnityEngine;
using Zenject;

public class CameraInstaller : MonoInstaller
{
    public Camera Camera;
    
    public override void InstallBindings()
    {
        BindCamera();
    }

    private void BindCamera()
    {
        Container.Bind<Camera>().FromInstance(Camera).AsSingle();
    }
}
