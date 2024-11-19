using System;

namespace GamePlay
{
    [Serializable]
    public class ProjectileConfig
    {
        public Projectile Prefab;
        public float Speed;
        public float Damage;
        public float MaxAge;

        public ProjectileContext ToContext()
        {
            return new ProjectileContext(Speed, Damage, MaxAge);
        }
    }
}
