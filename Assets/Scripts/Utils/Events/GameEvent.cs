using System.Collections.Generic;
using UnityEngine;

namespace CrazyPig.Events
{
    [CreateAssetMenu]
    public class GameEvent : ScriptableObject
    {
        [TextArea(5, 5)]
        [SerializeField] private string DeveloperDesctription = "";

        private List<GameEventListener> eventListeners
            = new List<GameEventListener>();

        public void Raise()
        {
            for (int i = eventListeners.Count - 1; i >= 0; i--)
                eventListeners[i].OnEventRaised();
        }

        public void RegisterListener(GameEventListener listener)
        {
            if (!eventListeners.Contains(listener))
                eventListeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener listener)
        {
            if (eventListeners.Contains(listener))
                eventListeners.Remove(listener);
        }
    }
}
