using UnityEngine;
using System.Collections.Generic;

namespace CrazyPig.UI
{
    [CreateAssetMenu]
    public class MemeDeathQuotes : ScriptableObject
    {
        [SerializeField] private List<string> quotes;

        public string GetRandomQuote()
        {
            return quotes[Random.Range(0, quotes.Count)];
        }
    }
}
