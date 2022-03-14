using UnityEngine;

public class UIPanelsView : MonoBehaviour
{
    [SerializeField] private UIPanel winPanel;
    [SerializeField] private UIPanel losePanel;

    public void ShowWinPanel()
    {
        winPanel.Show();
    }

    public void HideWinPanel()
    {
        winPanel.Hide();
    }
    
    public void ShowLosePanel()
    {
        losePanel.Show();
    }

    public void HideLosePanel()
    {
        losePanel.Hide();
    }
}
