using UnityEngine;
using System.Collections;
using CrazyPig.Utils;

namespace CrazyPig.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        [Tooltip("If checked, number of enemies won't be randomed.")]
        [SerializeField] private bool useConstant = false;

        [Range(1, 10)]
        [SerializeField] private int constSpawnCount = 3;
        [Range(1, 10)]
        [SerializeField] private int minSpawnCount = 1;
        [Range(1, 20)]
        [SerializeField] private int maxSpawnCount = 4;
            
        [Tooltip("Time between spwans in a row.")]
        [SerializeField] private float spawnGap = 1f;

        [Tooltip("If this field is checked, enemies will be spawned after they're all dead. Otherwise they will spawn based on timer.")]
        [SerializeField] private bool waitForEnemiesDeath;

        [SerializeField] private float timeBeforeSpawn = 20f;
        [SerializeField] private GameObject[] enemies;
        [SerializeField] private EnemySet enemiesSet;
        [SerializeField] private Transform[] spawnPoints;

        private void Start()
        {
            if (!waitForEnemiesDeath)
                StartCoroutine(SpawnEnemiesContinuously());
            else
                StartCoroutine(SpawnEnemiesInQueue());
        }

        private IEnumerator SpawnEnemiesContinuously()
        {
            yield return new WaitForSeconds(timeBeforeSpawn);

            int number = useConstant
                         ? constSpawnCount
                         : Random.Range(minSpawnCount, maxSpawnCount);

            for (int i = number; i > 0; i--)
            {
                SpawnRandomEnemy();
                yield return new WaitForSeconds(spawnGap);
            }
        }

        private IEnumerator SpawnEnemiesInQueue()
        {
            int number = useConstant 
                         ? constSpawnCount 
                         : Random.Range(minSpawnCount, maxSpawnCount);

            while(true)
            {
                if (enemiesSet.Items.Count == 0)
                    for (int i = number; i > 0; i--)
                    {
                        SpawnRandomEnemy();
                        yield return new WaitForSeconds(spawnGap);
                    }    

                yield return new WaitForSeconds(1f);
            }
        }

        private void SpawnRandomEnemy()
        {
            GameObject randomEnemy = enemies[Random.Range(0, enemies.Length)];
            Vector3 randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
            Instantiate(randomEnemy, randomPoint, Quaternion.identity, transform);
        }
    }
}
