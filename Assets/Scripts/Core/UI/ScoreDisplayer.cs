using UnityEngine;
using TMPro;
using CrazyPig.Utils;

namespace CrazyPig.UI
{
    public class ScoreDisplayer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private IntReference score;
        private int previousScore = 0;

        private void Update()
        {
            if(score.Value != previousScore)
            {
                previousScore = score.Value;
                text.text = "Score: " + score.Value;
            }
        }
    }
}
