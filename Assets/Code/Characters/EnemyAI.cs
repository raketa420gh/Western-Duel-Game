using UnityEngine;
using System.Collections;

namespace Raketa420
{
    public class EnemyAI : MonoBehaviour
    {
        private Enemy enemy;

        private void Awake()
        {
            enemy = GetComponent<Enemy>();
        }

        public IEnumerator ShootingRoutine()
        {
            enemy.Animation.PlayPistolIdle();

            yield return new WaitForSeconds(enemy.ReactionFactor);

            if (enemy.IsAlive)
            {
                enemy.Gun.Shoot();
            }

            yield break;
        }

        public void StartShootingRoutine()
        {
            StartCoroutine(nameof(ShootingRoutine));
        }
    }
}
