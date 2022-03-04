using Raketa420;
using UnityEngine;
using Zenject;

public class PlayerCharacterInstaller : MonoInstaller
{
    public Transform PlayerSpawnPoint;
    public Vector3 PlayerSpawnRotationAngle;
    public Player PlayerCharacterPrefab;
    
    public override void InstallBindings()
    {
        BindPlayerCharacter();
    }

    private void BindPlayerCharacter()
    {
        Quaternion playerSpawnRotation = Quaternion.Euler(PlayerSpawnRotationAngle);
        
        Player playerCharacter = Container.InstantiatePrefabForComponent<Player>(PlayerCharacterPrefab,
            PlayerSpawnPoint.position, playerSpawnRotation, null);

        Container.Bind<Player>().FromInstance(playerCharacter).AsSingle();
    }
}