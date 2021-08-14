using UnityEngine;
using TMPro;
using DG.Tweening;

namespace CrazyPig.Utils
{
    [CreateAssetMenu(menuName = "Tweening/TextFade")]
    public class TextFade : TweenPlugin
    {
        private Sequence fadeSeq;

        public override void Tween(GameObject target)
        {
            TextMeshProUGUI text
                = target.transform.parent.GetComponentInChildren<TextMeshProUGUI>();
            InterruptSequence();
            fadeSeq = DOTween.Sequence();
            fadeSeq.Append(text.DOFade(0f, Duration));
        }

        public override void Untween(GameObject target)
        {
            TextMeshProUGUI text
                = target.transform.parent.GetComponentInChildren<TextMeshProUGUI>();
            InterruptSequence();
            fadeSeq = DOTween.Sequence();
            fadeSeq.Append(text.DOFade(1f, Duration / 3));
        }

        public override void InterruptSequence()
        {
            fadeSeq.Kill();
        }
    }
}
