using UnityEngine;

namespace GamePlay
{
    public abstract class EnemyView : MonoBehaviour
    {
        public abstract void TakeDamageAnimation();
        public abstract void StartIdleAnimation();
        public abstract void StartRunAnimation();
        public abstract void StopRunAnimation();
        public abstract void DieAnimation();
    }
}
