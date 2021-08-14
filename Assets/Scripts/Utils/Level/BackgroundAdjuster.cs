using UnityEngine;

namespace CrazyPig
{
    public class BackgroundAdjuster : MonoBehaviour
    {
        [SerializeField] private float sourceWidth = 2160f;

        private void Start()
        {
            if (Screen.width < sourceWidth)
                transform.localScale = new Vector3(.9f, 1, 1.1f);
        }
    }
}
