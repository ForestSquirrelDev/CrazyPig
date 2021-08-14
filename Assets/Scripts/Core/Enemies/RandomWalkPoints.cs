using UnityEngine;

namespace CrazyPig.Enemies
{
    /// <summary>
    /// Points enemies will be walking towards when not chasing player.
    /// </summary>
    [CreateAssetMenu]
    public class RandomWalkPoints : ScriptableObject
    {
        [SerializeField] private GameObject pointsPrefab;
        private Transform[] walkPoints;

        private void OnEnable() => AddPoints();

        public void AddPoints()
        {
           walkPoints = pointsPrefab.GetComponentsInChildren<Transform>();
        }

        public Transform GetRandomPoint()
        {
            return walkPoints[Random.Range(0, walkPoints.Length)];
        }
    }
}
