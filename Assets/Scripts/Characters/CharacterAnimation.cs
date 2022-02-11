using UnityEngine;

namespace Raketa420
{
    public class CharacterAnimation : MonoBehaviour
    {
        [SerializeField] Animator animator;

        public void PlayIdle()
        {
            animator.SetTrigger($"Idle");
        }

        public void PlayPistolIdle()
        {
            animator.SetTrigger($"PistolIdle");
        }
    }
}