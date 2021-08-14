using UnityEngine;
using UnityEngine.Events;
using CrazyPig.Utils;
using CrazyPig.Shared;

namespace CrazyPig.Player
{
    public class PigHealth : MonoBehaviour, IDamageable
    {
        private UnityEvent OnPigDied;
        private FloatVariable healthVariable;

        public void Construct(UnityEvent uEvent, FloatVariable health, float maxHealth)
        {
            OnPigDied = uEvent;
            this.healthVariable = health;
            this.healthVariable.Value = maxHealth;
        }

        public void TakeDamage(float value)
        {
            healthVariable.Value -= value;
            CheckHealth();
        }

        public void CheckHealth()
        {
            if (healthVariable.Value <= 0)
            {
                Debug.Log("Emergency: user death imminent.");
                OnPigDied.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
