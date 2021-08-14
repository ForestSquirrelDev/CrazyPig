using UnityEngine;
using TMPro;
using CrazyPig.Utils;

namespace CrazyPig.UI
{
    /// <summary>
    /// Respoinsible for displaying bomb timer.
    /// </summary>
    public class TimerController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private IntReference bombTimer;
        [SerializeField] private TweenPlugin textFade;

        private bool timerAllowed;

        private void Update()
        {
            if (timerAllowed)
                UpdateText();
        }

        private void UpdateText()
        {
            text.text = bombTimer.Value.ToString();

            if (bombTimer.Value >= 3 && text.color != Color.green)
                text.color = Color.green;

            if (bombTimer.Value <= 2 && text.color != Color.red)
                text.color = Color.red;
        }

        public void EnableTimer()
        {
            textFade.Untween(gameObject);
            timerAllowed = true;
        }

        public void DisableTimer()
        {
            textFade.Tween(gameObject);
            text.text = 0.ToString();
            timerAllowed = false;         
        }
    }
}
