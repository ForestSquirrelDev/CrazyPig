using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using CrazyPig.Utils;
using CrazyPig.Player;

namespace CrazyPig.Environment
{
    /// <summary>
    /// Whole bomb sequence management.
    /// </summary>
    public class BombController : MonoBehaviour
    {
        [Tooltip("Bomb placement offset relative to player.")]
        [SerializeField] private Vector3 bombOffset = Vector3.zero;
        [SerializeField] private Vector3 explosionRadius = new Vector2(4.0f, 4.0f);

        [SerializeField] private UnityEvent OnBombPicked;
        [SerializeField] private UnityEvent OnBombExploded;

        [Range(1, 10)]
        [Tooltip("Explosion timer.")]
        [SerializeField] private int bombCounter = 5;
        [SerializeField] private IntVariable timer;
        [SerializeField] GameObject explosionPrefab;
        [SerializeField] GameObject explosionRadiusDisplayer;
        [SerializeField] private BombsSet bombsSet;
        [SerializeField] private GameObject FX;

        private static bool pickupAllowed = true;
        private bool isReleased;
        private Vector3 startPosition;
        private TweenPlugin tweenPlugin;

        private void Awake() => pickupAllowed = true;

        private void Start()
        {
            bombsSet.AddItem(this);

            startPosition = transform.position;
            tweenPlugin = ScriptableObject.CreateInstance<TransformBounce>();
            tweenPlugin.Tween(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IPlayer player = collision.gameObject.GetComponent<IPlayer>();
            if(player != null)
            {
                if (!pickupAllowed)
                    return;
                else
                    pickupAllowed = false;

                if (tweenPlugin != null)
                    tweenPlugin.InterruptSequence();

                StickToPlayer(player);
                ShowExplosionRadius();
                StartCoroutine(StartExplosionCountdown());
                OnBombPicked.Invoke();
            }
        }

        private void ShowExplosionRadius()
        {
            var radius = Instantiate(original: explosionRadiusDisplayer,
                                     position: transform.position,
                                     rotation: Quaternion.identity,
                                     parent: transform);

            radius.transform.localScale = explosionRadius;
        }

        public void StickToPlayer(IPlayer player)
        {
            var targetTransform = player.GetTransform();
            StartCoroutine(UpdatePosition(targetTransform));
        }

        public void ReleaseBomb()
        {
            if(!pickupAllowed && transform.position != startPosition && !isReleased)
            {
                isReleased = true;
                transform.position -= bombOffset;
                transform.parent = null;
            }
        }

        private IEnumerator StartExplosionCountdown()
        {
            timer.Value = bombCounter;

            while(timer.Value <= bombCounter && timer.Value > 0)
            {
                yield return new WaitForSeconds(1f);
                timer.Value--;
            }

            pickupAllowed = true;
            Explode();
        }

        private IEnumerator UpdatePosition(Transform target)
        {
            while(!isReleased)
            {
                transform.position = target.position + bombOffset;
                yield return null;
            }
        }

        private void Explode()
        {
            var explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity, parent: null);
            OnBombExploded.Invoke();
            
            explosion.transform.localScale = explosionRadius;
            Instantiate(FX, transform.position, Quaternion.identity);

            bombsSet.RemoveItem(this);

            Destroy(explosion, 0.1f);
            Destroy(gameObject, 0.1f);
        }
    }
}
