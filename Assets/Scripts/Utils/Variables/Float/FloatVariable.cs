using UnityEngine;

namespace CrazyPig.Utils
{
    [CreateAssetMenu(menuName = "Variables/FloatVariable")]
    public class FloatVariable : ScriptableObject
    {
        [TextArea(5, 5)]
        [SerializeField] private string DeveloperDescription = "";

        public float Value { get; set; }

        public static implicit operator float(FloatVariable f) => f.Value;
    }
}
