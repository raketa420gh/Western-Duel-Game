using UnityEngine;
using Zenject;

public class RestartButton : MonoBehaviour
{
    private SceneLoader sceneLoader;
    
    [Inject]
    public void Construct(SceneLoader sceneLoader)
    {
        this.sceneLoader = sceneLoader;
    }

    public void RestartScene()
    {
        sceneLoader.ReloadScene();
    }
}
