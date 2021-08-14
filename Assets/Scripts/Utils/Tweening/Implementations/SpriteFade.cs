using UnityEngine;
using DG.Tweening;

namespace CrazyPig.Utils
{
    [CreateAssetMenu(menuName = "Tweening/SpriteFade")]
    public class SpriteFade : TweenPlugin
    {
        private Sequence fadeSeq;

        public override void Tween(GameObject target)
        {
            SpriteRenderer spriteRenderer = target.gameObject.GetComponent<SpriteRenderer>();
            fadeSeq = DOTween.Sequence();

            fadeSeq.Append(spriteRenderer.DOFade(0f, duration));
        }

        public override void InterruptSequence()
        {
            fadeSeq.Kill();
        }
    }
}
