using UnityEngine;

namespace Raketa420
{
    public class UserInput : MonoBehaviour
    {
        [SerializeField] private Joystick joystick;

        public bool IsEnabled { get; private set; }

        public void Initialize()
        {
            
        }

        public void Enable(bool isActive)
        {
            IsEnabled = isActive;
            joystick.gameObject.SetActive(isActive);
        }

        public bool IsJoystickDragged()
        {
            return joystick.Horizontal != 0f || joystick.Vertical != 0f;
        }

        public Vector3 GetInputDirection()
        {
            return joystick.Direction;
        }
    }
}