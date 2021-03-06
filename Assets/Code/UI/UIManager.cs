using UnityEngine;
using UnityEngine.UI;

namespace Raketa420
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private UIPanel winPanel;
        [SerializeField] private UIPanel losePanel;

        public void ShowWinPanel()
        {
            winPanel.Show();
        }

        public void ShowLosePanel()
        {
            losePanel.Show();
        }
    }
}
