using CrazyPig.Shared;
using UnityEngine;

namespace CrazyPig.Enemies
{
    public class DamageDealer : MonoBehaviour
    {
        private float damage;
        private AISettings aiSettings;

        public void Construct(AISettings aiSettings)
        {
            this.aiSettings = aiSettings;
            damage = this.aiSettings.Damage;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            IDamageable damageable;

            if (collision.gameObject.CompareTag("Player"))
            {
                damageable = collision.gameObject.GetComponent<IDamageable>();
                damageable?.TakeDamage(damage);
            }
        }
    }
}
