using Raketa420;
using UnityEngine;
using Zenject;

public class EnemyCounterInstaller : MonoInstaller
{
    public EnemyCounter counterPrefab;

    public override void InstallBindings()
    {
        BindEnemyCounter();
    }

    private void BindEnemyCounter()
    {
        EnemyCounter counter = Container.InstantiatePrefabForComponent<EnemyCounter>(counterPrefab, 
            Vector3.zero, Quaternion.identity, null);

        Container.Bind<EnemyCounter>().FromInstance(counter).AsSingle();
    }
}