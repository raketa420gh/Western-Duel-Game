using UnityEngine;
using Zenject;

namespace Raketa420
{
    public class EnemyGun : MonoBehaviour, IGun
    {
        [SerializeField] private BulletEnemy bullet;
        [SerializeField] private Transform bulletsParent;
        [SerializeField] private Transform muzzle;

        private Player player;

        [Inject]
        public void Construct(Player player)
        {
            this.player = player;
        }

        public void Shoot()
        {
            ProjectileBase bulletObject = Instantiate(bullet, muzzle.transform.position, Quaternion.identity, bulletsParent);
            bulletObject.SetTarget(player.transform.position + (Vector3.up * 1.2f));
        }
    }
}