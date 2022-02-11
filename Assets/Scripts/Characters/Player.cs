using System;

namespace Raketa420
{
    public class Player : Character
    {
        private PlayerGun gun;
        private bool isAlive;

        public bool IsAlive => isAlive;
        public PlayerGun Gun => gun;

        public event Action<Player> OnCreated;
        public event Action<Player> OnKilled;

        protected override void Awake()
        {
            base.Awake();
            gun = GetComponentInChildren<PlayerGun>();
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
