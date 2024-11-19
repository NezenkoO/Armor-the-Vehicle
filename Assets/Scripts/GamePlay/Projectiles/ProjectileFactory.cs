using System;
using UnityEngine;
using Core;

namespace GamePlay
{
    [CreateAssetMenu]
    public class ProjectileFactory : GameObjectFactory
    {
        [SerializeField] private ProjectileConfig _bullet;

        public Projectile Get(ProjectileType type)
        {
            var config = GetConfig(type);
            Projectile instance = CreateGameObjectInstance(config.Prefab);
            instance.Initialize(config.ToContext());
            return instance;
        }

        private ProjectileConfig GetConfig(ProjectileType type)
        {
            switch (type)
            {
                case ProjectileType.Bullet:
                    return _bullet;
            }

            throw new NotImplementedException($"No config for: {type}");
        }
    }

    public enum ProjectileType
    {
        Bullet
    }
}