using System;
using UnityEngine;
using Zenject;

public class GameFactory : MonoBehaviour, IGameFactory
{
    public GameObject PlayerCharacterGameObject { get; private set; }
    public event Action OnPlayerCharacterCreated;
    
    private AssetProvider assetProvider;

    [Inject]
    public void Construct(AssetProvider assetProvider)
    {
        this.assetProvider = assetProvider;
    }

    public GameObject CreatePlayerCharacter(Vector3 initialPointPosition)
    {
        PlayerCharacterGameObject = assetProvider.Instantiate(AssetPath.PlayerCharacterPath, initialPointPosition);
        OnPlayerCharacterCreated?.Invoke();
        
        return PlayerCharacterGameObject;
    }
}