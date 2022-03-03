using Raketa420;
using UnityEngine;
using Zenject;

public class PlayerCharacterInstaller : MonoInstaller
{
    public Transform PlayerStartPoint;
    public Player PlayerCharacterPrefab;
    
    public override void InstallBindings()
    {
        Player playerCharacter = Container.InstantiatePrefabForComponent<Player>(PlayerCharacterPrefab, 
            PlayerStartPoint.position, Quaternion.identity, null);

        Container.Bind<Player>().FromInstance(playerCharacter).AsSingle();
    }
}