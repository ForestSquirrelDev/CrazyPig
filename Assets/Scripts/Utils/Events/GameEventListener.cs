using UnityEngine;
using UnityEngine.Events;

namespace CrazyPig.Events
{
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField] private GameEvent Event;
        [SerializeField] private UnityEvent Response;

        private void OnEnable()
        {
            Event.RegisterListener(this);
            Debug.Log("Registering listener. " + gameObject.name);
        }

        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            Response.Invoke();
        }
    }
}
