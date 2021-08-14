using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace CrazyPig.Utils
{
    [CreateAssetMenu(menuName = "Tweening/ImageFade")]
    public class ImageFade : TweenPlugin
    {
        private Sequence fadeSeq;

        public override void Tween(GameObject target)
        {
            Image image = target.GetComponent<Image>();

            fadeSeq = DOTween.Sequence();
            fadeSeq.Append(image.DOFade(1f, duration));
        }

        public override void Untween(GameObject target)
        {
            Image image = target.GetComponent<Image>();

            fadeSeq = DOTween.Sequence();
            fadeSeq.Append(image.DOFade(0f, duration / 2));
        }

        public override void InterruptSequence()
        {
            fadeSeq.Kill();
        }
    }
}
