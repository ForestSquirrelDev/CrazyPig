using UnityEngine;
using UnityEngine.Events;
using CrazyPig.Utils;

namespace CrazyPig.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PigController : MonoBehaviour, IPlayer
    {
        [SerializeField] private UnityEvent OnPigDied;

        [Range(0.1f, 2.0f)]
        [Tooltip("Max health of the pig.")]
        [SerializeField] private float maxHealth = 1.0f;
        [Tooltip("If this field is checked, traditional input manager will be used. If not, mobile input will function instead.")]
        [SerializeField] private bool isEditor;

        [SerializeField] private FloatVariable healthVariable;
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private MovementSettings movementSettings;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private SpriteContainer sprites;

        private UniversalInput input;
        private PigHealth pigHealth;
        private PigMovement pigMovement;
        private PigRotator pigRotator;

        private void Awake()
        {
            if (rb == null)
                rb = GetComponent<Rigidbody2D>();
            if (spriteRenderer == null)
                spriteRenderer = GetComponent<SpriteRenderer>();

            pigHealth = gameObject.AddComponent(typeof(PigHealth)) as PigHealth;
            pigHealth.Construct(OnPigDied, healthVariable, maxHealth);

            input = new UniversalInput();
            pigMovement = new PigMovement(input, rb, movementSettings, isEditor);
            pigRotator = new PigRotator(input, spriteRenderer, sprites);
        }

        private void Update()
        {
            input.HandleInput();
            pigMovement.HandleMovement();
            pigRotator.HandleRotation();
        }

        public Transform GetTransform() => this.transform;
    }
}
