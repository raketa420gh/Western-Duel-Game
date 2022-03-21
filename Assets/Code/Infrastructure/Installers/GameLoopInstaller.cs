using UnityEngine;
using Zenject;

public class GameLoopInstaller : MonoInstaller
{
    public DuelModeGameLoop duelModeGameLoopPrefab;
    
    public override void InstallBindings()
    {
        BindGameLoop();
    }

    private void BindGameLoop()
    {
        DuelModeGameLoop duelModeGameLoop = Container.InstantiatePrefabForComponent<DuelModeGameLoop>(duelModeGameLoopPrefab, 
            Vector3.zero, Quaternion.identity, null);

        Container.Bind<DuelModeGameLoop>().FromInstance(duelModeGameLoop).AsSingle();
    }
}
