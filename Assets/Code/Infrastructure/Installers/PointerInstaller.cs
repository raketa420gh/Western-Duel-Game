using UnityEngine;
using Zenject;

public class PointerInstaller : MonoInstaller
{
    public Pointer PointerPrefab;
    public Vector3 SpawnPosition = new Vector3(1.8f,1.2f,11.3f);

    public override void InstallBindings()
    {
        BindPointer();
    }

    private void BindPointer()
    {
        Pointer pointer = Container.InstantiatePrefabForComponent<Pointer>(PointerPrefab, 
            SpawnPosition, Quaternion.identity, null);

        Container.Bind<Pointer>().FromInstance(pointer).AsSingle();
    }
}