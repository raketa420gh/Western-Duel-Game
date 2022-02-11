using UnityEngine;

namespace Raketa420
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Transform charactersParent;
        [SerializeField] private Transform[] startPoints;
        [SerializeField] private Player playerPrefab;
        [SerializeField] private Enemy[] enemyPrefabs;

        private void Start()
        {
            var player = SpawnPlayerAtRandomStartPoint();
            SpawnRandomEnemyAtRandomDistanceFromPlayer(player);
        }

        public Player SpawnPlayerAtRandomStartPoint()
        {
            var randomStartPointIndex = Random.Range(0, startPoints.Length);
            var randomStartPoint = startPoints[randomStartPointIndex];

            return SpawnPlayerCharacter(randomStartPoint.position);
        }

        public void SpawnRandomEnemyAtRandomDistanceFromPlayer(Player player)
        {
            var randomDistance = Random.Range(3f, 10f);
            var randomOffset = Random.Range(-0.5f, 0.5f);
            var randomEnemyIndex = Random.Range(0, enemyPrefabs.Length);

            var spawnPosition = new Vector3(player.transform.position.x + randomOffset,
                player.transform.position.y,
                player.transform.position.z + randomDistance);

            var spawnedEnemy = SpawnEnemy(enemyPrefabs[randomEnemyIndex], spawnPosition);
            spawnedEnemy.LookAtPlayer(player);
        }

        private GameObject SpawnObject(GameObject spawnedObject, Vector3 position)
        {
            Instantiate(spawnedObject, position, Quaternion.identity, charactersParent);

            return spawnedObject;
        }
        private Player SpawnPlayerCharacter(Vector3 position)
        {
            return SpawnObject(playerPrefab.gameObject, position).GetComponent<Player>();
        }

        private Enemy SpawnEnemy(Enemy enemy, Vector3 position)
        {
            return SpawnObject(enemy.gameObject, position).GetComponent<Enemy>();
        }
    }
}
