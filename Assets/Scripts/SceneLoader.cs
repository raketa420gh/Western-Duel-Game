using UnityEngine;
using UnityEngine.SceneManagement;

namespace Raketa420
{
    public class SceneLoader : MonoBehaviour
    {
        public void ReloadScene()
        {
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex));
        }

        public void LoadGameScene()
        {
            SceneManager.LoadScene(1);
        }

        public void LoadMainMenuScene()
        {
            SceneManager.LoadScene(0);
        }
    }
}
