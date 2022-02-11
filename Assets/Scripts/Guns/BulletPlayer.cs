using UnityEngine;

namespace Raketa420
{
    public class BulletPlayer : ProjectileBase
    {
        protected override void OnTriggerEnter(Collider other)
        {
            if (other.GetComponentInParent<CharacterRagdoll>())
            {
                var ragdoll = other.GetComponentInParent<CharacterRagdoll>();
                var rigidBody = other.GetComponent<Rigidbody>();
                var enemy = other.GetComponentInParent<Enemy>();
                var forceVector = Vector3.forward + Vector3.up;

                ragdoll.Activate();
                enemy.Die();
                rigidBody.AddForce(forceVector * base.ImpulseForce, ForceMode.Impulse);
            }

            base.OnTriggerEnter(other);
        }
    }
}
