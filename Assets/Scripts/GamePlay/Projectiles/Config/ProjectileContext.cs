using UnityEngine;

namespace GamePlay.Projectiles
{
    public readonly struct ProjectileContext
    {
        public Vector3 LaunchDirection { get; }
        public float Speed { get; }
        public int Damage { get; }
        public float MaxAge { get; }

        public ProjectileContext(Vector3 launchDirection, float speed, int damage, float maxAge)
        {
            LaunchDirection = launchDirection;
            Speed = speed;
            Damage = damage;
            MaxAge = maxAge;
        }
    }
}
