using UnityEngine;
using System;
using System.Collections;
using CrazyPig.Player;

namespace CrazyPig.Enemies
{
    /// <summary>
    /// Controls circle of enemy vision radius.
    /// </summary>
    public class EnemyLOS : MonoBehaviour
    {
        public event Action<Transform> OnPlayerSpotted;
        public event Action OnPlayerLost;

        private IPlayer player;
        private bool seeingPlayer;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            player = collision.gameObject.GetComponent<IPlayer>();

            if(player != null)
            {
                seeingPlayer = true;
                StartCoroutine(DetectPlayerContinuously());
            }    
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            player = collision.gameObject.GetComponent<IPlayer>();

            if(player != null)
            {
                seeingPlayer = false;
                OnPlayerLost?.Invoke();
            }
        }

        private IEnumerator DetectPlayerContinuously()
        {
            while(seeingPlayer)
            {
                OnPlayerSpotted?.Invoke(player?.GetTransform());
                yield return new WaitForFixedUpdate();
            }
        }
    }
}
