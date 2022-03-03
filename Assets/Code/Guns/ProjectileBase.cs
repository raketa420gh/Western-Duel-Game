using System;
using UnityEngine;

namespace Raketa420
{
    public abstract class ProjectileBase : MonoBehaviour
    {
        [SerializeField] private float speed = 50f;
        [SerializeField] private float lifeTime = 3f;
        [SerializeField] private float impulseForce = 110f;

        public event Action OnGotTarget;

        public Vector3 Target { get; private set; }

        public float ImpulseForce => impulseForce;

        public void SetTarget(Vector3 position)
        {
            Target = position;
        }

        private void OnEnable()
        {
            Destroy(gameObject, lifeTime);
        }

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, Target, speed * Time.deltaTime);
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
            OnGotTarget?.Invoke();
        }
    }
}
