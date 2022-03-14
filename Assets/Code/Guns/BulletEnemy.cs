using UnityEngine;

namespace Raketa420
{
    public class BulletEnemy : ProjectileBase
    {
        protected override void OnTriggerEnter(Collider other)
        {
            if (other.GetComponentInParent<CharacterRagdoll>())
            {
                var ragdoll = other.GetComponentInParent<CharacterRagdoll>();
                var rigidBody = other.GetComponent<Rigidbody>();
                var player = other.GetComponentInParent<Player>();
                var forceVector = -Vector3.forward + Vector3.up;

                ragdoll.Activate();
                player.Die();
                rigidBody.AddForce(forceVector * ImpulseForce, ForceMode.Impulse);
            }

            base.OnTriggerEnter(other);
        }
    }
}
