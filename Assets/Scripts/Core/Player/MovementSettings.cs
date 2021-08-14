using UnityEngine;

namespace CrazyPig.Player
{
    [CreateAssetMenu(menuName = "PlayerSettings/MovementSettings")]
    public class MovementSettings : ScriptableObject
    {
        [Range(1.0f, 10.0f)]
        [Tooltip("How fast the pig will move.")]
        [SerializeField] private float movementSpeed = 3.0f;

        public float MovementSpeed => movementSpeed;
    }
}
