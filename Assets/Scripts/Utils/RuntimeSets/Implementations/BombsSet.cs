using UnityEngine;
using CrazyPig.Environment;

namespace CrazyPig.Utils
{
    [CreateAssetMenu(menuName = "RuntimeSets/BombSet")]
    public class BombsSet : RuntimeSet<BombController>
    {
        private void OnDisable() => items.Clear();
    }
}
