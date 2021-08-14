using UnityEngine;
using DG.Tweening;

namespace CrazyPig.Utils
{
    [CreateAssetMenu(menuName = "Tweening/Bounce")]
    public class TransformBounce : TweenPlugin
    {
        [Min(1)]
        [SerializeField] private float targetScale = 1.3f;
        [SerializeField] private Vector3 startScale = Vector3.one;
        private Transform passedTransform;
        private Sequence bounceSeq;

        /// <summary>
        /// Infinite bounce.
        /// </summary>
        /// <param name="target">Target transform to tween.</param>
        public override void Tween(GameObject target)
        {
            bounceSeq = DOTween.Sequence();
            passedTransform = target.transform;

            bounceSeq.Append(target.transform.DOScale(targetScale, duration));
            bounceSeq.Insert(duration, target.transform.DOScale(startScale, duration));
            bounceSeq.InsertCallback(duration * 1.8f, () => Tween(passedTransform.gameObject));
        }

        public override void Untween(GameObject target)
        {
            bounceSeq = DOTween.Sequence();
            passedTransform = target.transform;

            bounceSeq.Append(passedTransform.DOScale(startScale, duration));
        }

        public override void InterruptSequence()
        {
            bounceSeq.Kill();
        }
    }
}
