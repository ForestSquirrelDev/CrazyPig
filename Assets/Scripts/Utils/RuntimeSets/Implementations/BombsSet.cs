using UnityEngine;
using CrazyPig.Environment;

namespace CrazyPig.Utils
{
    [CreateAssetMenu(menuName = "RuntimeSets/BombSet")]
    public class BombsSet : RuntimeSet<BombController>
    {
        private void OnDisable() => ClearItems();
        public void ClearItems() => items.Clear();
    }
}
