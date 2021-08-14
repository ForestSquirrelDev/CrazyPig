using UnityEngine;
using UnityEngine.AI;
using CrazyPig.Utils;

namespace CrazyPig.Enemies
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private RandomWalkPoints walkPoints;
        [SerializeField] private IntVariable scoreVariable;
        [SerializeField] private AISettings aiSettings;
        [SerializeField] private SpriteContainer firstSpriteSet;
        [SerializeField] private SpriteContainer secondSpriteSet;
        [SerializeField] private TweenPlugin deathFade;
        [SerializeField] private GameObject sightRadius;
        [SerializeField] private EnemySet enemySet;

        private EnemyHP enemyHP;
        private EnemyLOS sight;
        private EnemyAI AI;
        private DamageDealer damageDealer;
        private EnemyRotator enemyRotator;
        private NavMeshAgent agent;
        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            enemySet.AddItem(this);

            spriteRenderer = GetComponent<SpriteRenderer>();
            agent = GetComponentInParent<NavMeshAgent>();
            sight = sightRadius.GetComponent<EnemyLOS>();

            enemyHP = gameObject.AddComponent(typeof(EnemyHP)) as EnemyHP;
            damageDealer = gameObject.AddComponent(typeof(DamageDealer)) as DamageDealer;

            enemyHP.Construct(aiSettings, scoreVariable, deathFade);
            damageDealer.Construct(aiSettings);

            AI = new EnemyAI(walkPoints, agent, enemyHP, aiSettings, sight);
            enemyRotator = new EnemyRotator(agent, sight, spriteRenderer, firstSpriteSet, secondSpriteSet);
        }

        private void Start()
        {
            sightRadius.transform.localScale 
                = Vector3.one * aiSettings.VisionRadius;
            AI.GetNewPath();
        }

        private void Update()
        {
            AI.CheckPathCompletion();
            enemyRotator.RotateEnemy();
        }

        private void OnDisable() => enemySet.RemoveItem(this);
    }
}
