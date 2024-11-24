using System;
using UnityEngine;

namespace Utils
{
    [Serializable]
    public class LinkedInterface<T> : ISerializationCallbackReceiver where T : class
    {
        public T Value { get; private set; }

        [SerializeField] private MonoBehaviour _monoBeheavir;

        public void OnBeforeSerialize()
        {
            if (_monoBeheavir != null && _monoBeheavir is not T)
            {
                _monoBeheavir = null;
            }
        }

        public void OnAfterDeserialize()
        {
            Value = _monoBeheavir as T;
        }
    }
}