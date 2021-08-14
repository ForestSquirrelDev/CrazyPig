using UnityEngine;
using UnityEngine.SceneManagement;
using CrazyPig.Utils;

namespace CrazyPig.Scene
{
    public class RestartSequence : MonoBehaviour
    {
        [SerializeField] private IntVariable score;
        public void RestartScene()
        {
            score.Value = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
