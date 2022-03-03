using UnityEngine;
using UnityEngine.UI;

namespace Raketa420
{
    public class SettingMenuItem : MonoBehaviour
    {
        private Transform selfTransform;
        private Image image;

        public Transform SelfTransform => selfTransform;
        public Image Image => image;

        private void Awake()
        {
            image = GetComponent<Image>();
            selfTransform = transform;
        }
    }
}
