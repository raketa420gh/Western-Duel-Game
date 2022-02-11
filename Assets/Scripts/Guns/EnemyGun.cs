using UnityEngine;

namespace Raketa420
{
    public class EnemyGun : MonoBehaviour, ICharacterGun
    {
        [SerializeField] private BulletEnemy bullet;
        [SerializeField] private Transform bulletsParent;
        [SerializeField] private Transform muzzle;

        private Player player;

        public void Shoot()
        {
            player = FindObjectOfType<Player>();
            var bulletObject = Instantiate(bullet, muzzle.transform.position, Quaternion.identity, bulletsParent);
            var bulletEnemy = bulletObject.GetComponent<BulletEnemy>();

            bulletEnemy.SetTarget(player.transform.position + (Vector3.up * 1.2f));
        }
    }
}