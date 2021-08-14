using CrazyPig.Shared;
using UnityEngine;

namespace CrazyPig.Environment
{
    /// <summary>
    /// Circle of explosion. Script is attached to prefab that's instantiated when exploding.
    /// </summary>
    public class Explosion : MonoBehaviour
    {
        [SerializeField] private float damage = 0.5f;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var damageable = collision.gameObject.GetComponent<IDamageable>();
            damageable?.TakeDamage(damage);
        }
    }
}
