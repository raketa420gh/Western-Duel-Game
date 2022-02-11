using UnityEngine;
using UnityEngine.UI;

namespace Raketa420
{
    public class FloatingText : MonoBehaviour
    {
        [SerializeField] private Text text;

        public void SetText(string text)
        {
            this.text.text = text;
        }
    }
}