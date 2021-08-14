using UnityEngine;
using System;

namespace CrazyPig.Utils
{
    [Serializable]
    public class IntReference
    {
        [SerializeField] private IntVariable intVariable;

        public int Value => intVariable.Value;
    }
}
