using Raketa420;
using UnityEngine;
using Zenject;

public class EnemiesInstaller : MonoInstaller
{
    public Transform EnemySpawnPoint;
    public Vector3 EnemySpawnRotationAngle;
    public Enemy EnemyPrefab;
    
    public override void InstallBindings()
    {
        BindEnemy();
    }

    private void BindEnemy()
    {
        Quaternion enemySpawnRotation = Quaternion.Euler(EnemySpawnRotationAngle);
        
        Enemy enemy = Container.InstantiatePrefabForComponent<Enemy>(EnemyPrefab,
            EnemySpawnPoint.position, enemySpawnRotation, null);

        Container.Bind<Enemy>().FromInstance(enemy).AsTransient();
    }
}