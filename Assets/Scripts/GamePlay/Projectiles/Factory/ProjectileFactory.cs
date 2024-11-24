using System;
using UnityEngine;
using Core;
using Zenject;

namespace GamePlay.Projectiles
{
    [CreateAssetMenu]
    public class ProjectileFactory : ScriptableObject
    {
        [SerializeField] private Bullet _bulletPrefab;

        private DiContainer _diContainer;

        [Inject]
        public void Initialize(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public Projectile Create(ProjectileType type, ProjectileContext context)
        {
            var projectile = type switch
            {
                ProjectileType.Bullet => _diContainer.InstantiatePrefabForComponent<Projectile>(_bulletPrefab),
                _ => throw new NotImplementedException()
            };

            projectile.Initialize(context);
            return projectile;
        }
    }

    public enum ProjectileType
    {
        Bullet
    }
}
