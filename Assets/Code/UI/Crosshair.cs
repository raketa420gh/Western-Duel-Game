using UnityEngine;
using UnityEngine.UI;

namespace Raketa420
{
    public class Crosshair : MonoBehaviour
    {
        private Canvas canvas;
        private Image crosshairImage;
        private Vector2 startLocalPosition;
        private float moveSpeed = 750f;

        private void Awake()
        {
            canvas = GetComponentInParent<Canvas>();
            transform.parent = canvas.transform;
            crosshairImage = GetComponent<Image>();
            startLocalPosition = transform.localPosition;
        }

        public void Enable()
        {
            crosshairImage.gameObject.SetActive(true);
        }

        public void Disable()
        {
            crosshairImage.gameObject.SetActive(false);
        }

        public void ResetPosition()
        {
            transform.localPosition = startLocalPosition;
        }

        public void Move(Vector2 direction)
        {
            direction *= moveSpeed * Time.deltaTime;
            Vector3 localPosition = transform.localPosition;
            
            localPosition = new Vector2(localPosition.x + direction.x, localPosition.y + direction.y);
            transform.localPosition = localPosition;
        }
    }
}
