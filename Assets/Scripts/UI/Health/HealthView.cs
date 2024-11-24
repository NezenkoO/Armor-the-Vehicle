using Core.Health;
using UnityEngine;
using UnityEngine.UI;
using Utils.Extensions;

namespace Core.UI
{
    public abstract class HealthView : MonoBehaviour
    {
        protected IHealth Health { get; private set; }

        public abstract void Initialize(IHealth health);
    }
}