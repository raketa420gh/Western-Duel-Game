using System;
using UnityEngine;
using Zenject;

public class GameFactory : MonoBehaviour, IGameFactory
{
    public GameObject PlayerCharacterGameObject { get; private set; }
    public event Action OnPlayerCharacterCreated;
    
    private IAssetProvider assetProvider;

    [Inject]
    public void Construct(IAssetProvider assetProvider)
    {
        this.assetProvider = assetProvider;
    }

    public GameObject CreatePlayerCharacter(Vector3 initialPointPosition)
    {
        PlayerCharacterGameObject = assetProvider.Instantiate(AssetPath.PlayerCharacterPath, initialPointPosition);
        OnPlayerCharacterCreated?.Invoke();
        
        return PlayerCharacterGameObject;
    }

    public GameObject CreateFloatingText(Canvas canvas)
    {
        GameObject floatingTextPrefab = assetProvider.Instantiate(AssetPath.FloatingTextPath, canvas.transform.position);
        floatingTextPrefab.transform.SetParent(canvas.transform);
        floatingTextPrefab.transform.SetSiblingIndex(0);

        return floatingTextPrefab;
    }
}