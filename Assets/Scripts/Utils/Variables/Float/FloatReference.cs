using UnityEngine;
using System;

namespace CrazyPig.Utils
{
    [Serializable]
    public class FloatReference
    {
        [SerializeField] private FloatVariable Variable;

        public float Value => Variable.Value;
    }
}
