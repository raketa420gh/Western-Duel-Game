using System;
using UnityEngine;
using Zenject;

public class GameFactory : MonoBehaviour, IGameFactory
{
    public GameObject PlayerCharacterGameObject { get; private set; }
    public event Action OnPlayerCharacterCreated;

    [Inject]
    private AssetProvider assetProvider;

    public GameObject CreatePlayerCharacter(Vector3 initialPointPosition)
    {
        PlayerCharacterGameObject = assetProvider.Instantiate(AssetPath.PlayerCharacterPath, initialPointPosition);
        OnPlayerCharacterCreated?.Invoke();
        
        return PlayerCharacterGameObject;
    }
}