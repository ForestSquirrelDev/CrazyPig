using CrazyPig.Enemies;
using UnityEngine;

namespace CrazyPig.Utils
{
    [CreateAssetMenu(menuName = "RuntimeSets/EnemySet")]
    public class EnemySet : RuntimeSet<EnemyController>
    {
        private void OnDisable() => items.Clear();
    }
}
