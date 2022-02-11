using UnityEngine;

namespace Raketa420
{
    [RequireComponent(typeof(CharacterRagdoll))]
    [RequireComponent(typeof(CharacterAnimation))]

    public class Character : MonoBehaviour
    {
        private CharacterRagdoll ragdoll;
        private CharacterAnimation animation;

        public CharacterRagdoll Ragdoll => ragdoll;
        public CharacterAnimation Animation => animation;

        protected virtual void Awake()
        {
            ragdoll = GetComponent<CharacterRagdoll>();
            animation = GetComponent<CharacterAnimation>();
        }

        protected virtual void Start()
        {
            ragdoll.Deactivate();
        }
    }
}
