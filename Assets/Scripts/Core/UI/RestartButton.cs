using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CrazyPig.Utils;

namespace CrazyPig.UI
{
    public class RestartButton : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 0.001f;
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private Button button;
        [SerializeField] private TweenPlugin imageFade;
        [SerializeField] private TweenPlugin textFade;
        [SerializeField] private MemeDeathQuotes quotes;

        private void Update()
        {
            if(button.IsActive())
                button.gameObject.transform.Rotate(0, 0, rotationSpeed);
        }

        public void SuggestRestart()
        {
            text.gameObject.SetActive(true);
            text.text = quotes.GetRandomQuote();
            textFade.Untween(text.gameObject);

            button.gameObject.SetActive(true);
            imageFade.Tween(button.gameObject);
        }
    }
}
