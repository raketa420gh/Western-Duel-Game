using System;
using UnityEngine;

namespace Raketa420
{
    [RequireComponent(typeof(EnemyAI))]

    public class Enemy : Character
    {
        [SerializeField] [Range(0.5f, 3f)] private float reactionFactor = 1.25f;
        private EnemyAI ai;
        private EnemyGun gun;
        private bool isAlive;

        public EnemyAI AI => ai;
        public EnemyGun Gun => gun;
        public bool IsAlive => isAlive;
        public float ReactionFactor => reactionFactor;

        public event Action<Enemy> OnCreated;
        public event Action<Enemy> OnKilled;

        protected override void Awake()
        {
            base.Awake();

            ai = GetComponent<EnemyAI>();
            gun = GetComponentInChildren<EnemyGun>();
        }

        private void OnEnable()
        {
            isAlive = true;
            OnCreated?.Invoke(this);
        }

        public void Die()
        {
            isAlive = false;
            OnKilled?.Invoke(this);
        }
    }
}
