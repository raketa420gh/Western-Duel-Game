using UnityEngine;
using Zenject;

public class PlayButton : MonoBehaviour
{
    private const string Duel = "DuelScene";
    
    private SceneLoader sceneLoader;
    
    [Inject]
    public void Construct(SceneLoader sceneLoader)
    {
        this.sceneLoader = sceneLoader;
    }

    public void LoadDuelScene()
    {
        sceneLoader.Load(Duel);
    }
}