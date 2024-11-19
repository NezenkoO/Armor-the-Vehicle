using UnityEngine;

namespace GamePlay
{
    public abstract class Projectile : MonoBehaviour
    {
        public float Damage { get; protected set; }
        public float Speed { get; protected set; }

        protected float _maxAge;

        public IProjectileReclaimer ProjectileReclaimer { get; set; }

        public void Initialize(ProjectileContext projectileConfig)
        {
            Damage = projectileConfig.Damage;
            Speed = projectileConfig.Speed;
            _maxAge = projectileConfig.MaxAge;
        }

        public abstract void Launch(Vector3 direction);
    }
}
