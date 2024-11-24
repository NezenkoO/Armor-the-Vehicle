using System;
using UnityEngine;

namespace GamePlay.Projectiles
{
    [Serializable]
    public class ProjectileConfig
    {
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public float MaxAge { get; private set; }

        public ProjectileContext ToContext(Vector3 launchDirection)
        {
            return new ProjectileContext(
                launchDirection,
                Speed,
                Damage,
                MaxAge
            );
        }
    }
}