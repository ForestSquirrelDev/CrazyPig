using UnityEngine;

namespace CrazyPig.Utils
{
    [CreateAssetMenu(menuName = "Variables/IntVariable")]
    public class IntVariable : ScriptableObject
    {
        [TextArea(5, 5)]
        [SerializeField] private string DeveloperDescription = "";

        public int Value { get; set; }

        private void OnEnable() => Value = 0;

        private void OnDisable() => Value = 0;

        public static implicit operator int(IntVariable i) => i.Value;
    }
}
