using UnityEngine;
using UnityEngine.UI;

namespace Raketa420
{
    public class Crosshair : MonoBehaviour
    {
        [SerializeField] private UserInput input;

        private RectTransform rectTransform;
        private Image crosshairImage;
        private Vector2 startLocalPosition;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            crosshairImage = GetComponent<Image>();
            startLocalPosition = transform.localPosition;
        }

        private void Update()
        {
            if (!input.IsEnabled)
                return;

            var inputDirection = new Vector2(input.GetInputDirection().x, input.GetInputDirection().y);
            Move(inputDirection, 750f);
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

        private void Move(Vector2 direction, float speed)
        {
            direction *= speed * Time.deltaTime;
            transform.localPosition = new Vector2(transform.localPosition.x + direction.x, transform.localPosition.y + direction.y);
        }
    }
}
