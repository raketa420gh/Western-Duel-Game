using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Raketa420
{
    public class Crosshair : MonoBehaviour
    {
        private RectTransform rectTransform;
        private Image crosshairImage;
        private Vector2 startLocalPosition;
        private IInputService inputService;
        private float moveSpeed = 750f;
        
        [Inject]
        public void Construct(IInputService inputService)
        {
            this.inputService = inputService;
        }

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            crosshairImage = GetComponent<Image>();
            startLocalPosition = transform.localPosition;
        }

        private void Update()
        {
            if (!inputService.IsEnabled)
                return;

            var inputDirection = new Vector2(inputService.Axis.x, inputService.Axis.y);
            Move(inputDirection, moveSpeed);
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
