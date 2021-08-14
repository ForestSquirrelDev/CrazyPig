using UnityEngine;
using UnityEngine.UI;
using CrazyPig.Utils;

namespace CrazyPig.UI
{
    public class HealthDisplayer : MonoBehaviour
    {
        [SerializeField] private FloatReference health;
        [SerializeField] private Image image;

        private float previousCount = 1.0f;
        private float maxHealth;

        private void Awake() => maxHealth = health.Value;

        private void Update()
        {
            if (previousCount != health.Value)
                UpdateImage();
        }

        private void UpdateImage()
        {
            float percentage = health.Value / maxHealth;
            image.fillAmount = percentage;
            previousCount = health.Value;
        }
    }
}
