using UnityEngine;
using UnityEngine.UI;
using CrazyPig.Utils;

namespace CrazyPig.UI
{
    public class ReleaseBombButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private TweenPlugin bounceTweener;
        [SerializeField] private TweenPlugin fadeTweener;

        private GameObject targetObject;

        private void Awake() => targetObject = button.gameObject;

        public void ActivateButton()
        {
            fadeTweener.Tween(targetObject);
            bounceTweener.Tween(targetObject);
        }

        public void DeactivateButton()
        {
            fadeTweener.Untween(targetObject);
            bounceTweener.InterruptSequence();
            bounceTweener.Untween(targetObject);
        }
    }
}
