using UnityEngine;
using System;
using System.Collections.Generic;

namespace Raketa420
{
    public class EnemyCounter : MonoBehaviour
    {
        public event Action OnAllEnemiesDied;

        private Enemy[] enemies;
        
        private readonly List<Enemy> enemiesList = new List<Enemy>();

        public Enemy[] Enemies => enemies;

        private void OnEnable()
        {
            enemies = FindObjectsOfType<Enemy>();

            foreach (var enemy in enemies)
            {
                enemy.OnCreated += OnEnemyCreated;
                enemy.OnKilled += OnEnemyKilled;
            }
        }

        private void OnDisable()
        {
            foreach (var enemy in enemies)
            {
                enemy.OnCreated -= OnEnemyCreated;
                enemy.OnKilled -= OnEnemyKilled;
            }
        }

        private void OnEnemyCreated(Enemy enemy)
        {
            enemiesList.Add(enemy);
        }

        private void OnEnemyKilled(Enemy enemy)
        {
            if (enemiesList.Contains(enemy))
            {
                enemiesList.Remove(enemy);
            }

            if (enemiesList.Count == 0)
            {
                OnAllEnemiesDied?.Invoke();
            }
        }
    }
}
