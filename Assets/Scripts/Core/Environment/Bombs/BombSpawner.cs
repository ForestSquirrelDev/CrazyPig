using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CrazyPig.Utils;

namespace CrazyPig.Environment
{
    /// <summary>
    /// Spawns set number of bombs when there is no more on the map.
    /// </summary>
    public class BombSpawner : MonoBehaviour
    {
        [Tooltip("If this field is checked, constant number of bombs will be spawned. Otherwise it will be randomed.")]
        [SerializeField] private bool useConstant;
        [SerializeField] private float respawnTime = 5.0f;
        [SerializeField] private int minBombsCount = 1;
        [SerializeField] private int maxBombsCount = 10;
        [SerializeField] private int constBombsCount = 5;

        [SerializeField] private GameObject bombPrefab;
        [SerializeField] private List<Transform> spawningPoints;
        [SerializeField] private BombsSet allBombs;
        private List<Transform> allPoints = new List<Transform> { };

        private void Awake()
        {
            allBombs.ClearItems();
        }

        private void Start()
        {
            SpawnBombs();
            StartCoroutine(RecalculateBombs());
        }

        private void SpawnBombs()
        {
            allPoints = spawningPoints;
            int count = useConstant ? constBombsCount : Random.Range(minBombsCount, maxBombsCount);

            for (int i = count; i > 0; i--)
            {
                Transform randomPoint = spawningPoints[Random.Range(0, spawningPoints.Count)].transform;
                Instantiate(bombPrefab, randomPoint.position, Quaternion.identity);
                allPoints.Remove(randomPoint);
            }
        }

        private IEnumerator RecalculateBombs()
        {
            yield return new WaitForSeconds(1f);
            Debug.Log(allBombs.Items.Count);
            while(true)
            {
                if(allBombs.Items.Count == 0)
                {
                    yield return new WaitForSeconds(respawnTime);
                    SpawnBombs();
                }
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}
