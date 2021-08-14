using UnityEngine;

namespace CrazyPig
{
    [CreateAssetMenu]
    public class SpriteContainer : ScriptableObject
    {
        [Tooltip("4 sprites available to return. Rotation indexes: 0 - top, 1 - bottom, 2 - left, 3 - right.")]
        [SerializeField] protected Sprite[] sprites;

        public Sprite RotationTop => sprites[0];
        public Sprite RotationBottom => sprites[1];
        public Sprite RotationLeft => sprites[2];
        public Sprite RotationRight => sprites[3];
    }
}
