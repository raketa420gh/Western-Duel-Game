using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour, IService
{
    public void Load(string name, Action onLoaded = null)
    {
        StartCoroutine(LoadScene(name, onLoaded));
    }

    public void ReloadScene(Action onLoaded = null)
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().name, onLoaded));
    }
    
    private IEnumerator LoadScene(string nextScene, Action OnLoaded = null)
    {
        if (SceneManager.GetActiveScene().name == nextScene)
        {
            OnLoaded?.Invoke();
            yield break;
        }

        AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);

        while (!waitNextScene.isDone)
        {
            yield return null;
        }

        OnLoaded?.Invoke();
    }
}