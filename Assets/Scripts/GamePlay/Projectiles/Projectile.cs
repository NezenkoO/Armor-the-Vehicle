using UnityEngine;

namespace GamePlay.Projectiles
{
    public abstract class Projectile : MonoBehaviour
    {
        public ProjectileContext Context { get; private set; }
        public bool IsInitialized { get; private set; }

        public void Initialize(ProjectileContext context)
        {
            Context = context;
            IsInitialized = true;
            OnInitialize();
        }

        public abstract void OnInitialize();
    }
}
