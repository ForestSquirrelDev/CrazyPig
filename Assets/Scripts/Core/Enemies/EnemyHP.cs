using UnityEngine;
using System;
using CrazyPig.Utils;
using CrazyPig.Shared;

namespace CrazyPig.Enemies
{
    /// <summary>
    /// Responsible for enemy HP and adding score by death.
    /// </summary>
    public class EnemyHP : MonoBehaviour, IDamageable
    {
        public event Action OnDeathOccured;

        private TweenPlugin fadeSequence;
        private IntVariable scoreVariable;

        private float health;
        private int scorePerDeath = 1;
        
        public void Construct
            (AISettings aiSettings, IntVariable intVariable, TweenPlugin tweener)
        {
            health = aiSettings.MaxHealth;
            this.scorePerDeath = aiSettings.ScorePerDeath;
            this.scoreVariable = intVariable;
            this.fadeSequence = tweener;
        }

        public void TakeDamage(float value)
        {
            health -= value;
            CheckHealth();
        }

        public void CheckHealth()
        {
            if (health <= 0)
            {
                scoreVariable.Value += scorePerDeath;
                fadeSequence.Tween(gameObject);
                OnDeathOccured?.Invoke();
                Destroy(transform.parent.gameObject, fadeSequence.Duration);
            }
        }
    }
}
