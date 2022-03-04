using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Raketa420
{
    public class Crosshair : MonoBehaviour
    {
        private Canvas canvas;
        private Image crosshairImage;
        private Vector2 startLocalPosition;
        private float moveSpeed = 750f;
        
        [Inject]
        public void Construct(Canvas canvas)
        {
            this.canvas = canvas;
        }

        private void Awake()
        {
            transform.parent = canvas.transform;
            crosshairImage = GetComponent<Image>();
            startLocalPosition = transform.localPosition;
        }

        private void Update()
        {

            //var inputDirection = new Vector2(inputService.Axis.x, inputService.Axis.y);
            //Move(inputDirection, moveSpeed);
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
