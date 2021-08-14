using UnityEngine;

namespace CrazyPig.Utils
{
    public abstract class TweenPlugin : ScriptableObject
    {
        [SerializeField] protected float duration = 1.0f;
        public float Duration => duration;

        public abstract void Tween(GameObject target);
        public abstract void InterruptSequence();
        public virtual void Untween(GameObject target)
        { }
    }
}
