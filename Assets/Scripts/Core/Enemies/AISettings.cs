using UnityEngine;

namespace CrazyPig.Enemies
{
    /// <summary>
    /// Parameters of AI. Values are deployed into target classes on awake.
    /// </summary>
    [CreateAssetMenu]
    public class AISettings : ScriptableObject
    {
        [SerializeField] private float defaultSpeed = 1.0f;
        [SerializeField] private float rageSpeed = 1.5f;
        [SerializeField] private float visionRadius = 40.0f;
        [SerializeField] private float maxHealth = 0.5f;
        [SerializeField] private float damage = 0.5f;
        [SerializeField] private int scorePerDeath = 1;

        public float DefaultSpeed => defaultSpeed;
        public float RageSpeed => rageSpeed;
        public float VisionRadius => visionRadius;
        public float MaxHealth => maxHealth;
        public float Damage => damage;
        public int ScorePerDeath => scorePerDeath;
    }
}
