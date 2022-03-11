using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private Image backgroundImage;

    public void SetText(string text)
    {
        this.text.text = text;
    }

    public void SetBackgroundImageColor(Color color)
    {
        backgroundImage.color = color;
    }
}