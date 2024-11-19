using UnityEngine;
using Core;

namespace GamePlay
{
    public class EnemyFactory : GameObjectFactory
    {
        [SerializeField] private EnemyConfig _zombie;

        public Enemy Get(EnemyType type)
        {
            var config = GetConfig(type);
            Enemy instance = CreateGameObjectInstance(config.Prefab);
            instance.Initialize(config.ToContext());
            return instance;
        }

        private EnemyConfig GetConfig(EnemyType type)
        {
            switch (type)
            {
                case EnemyType.Zombie:
                    return _zombie;
            }
            Debug.LogError($"No config for: {type}");
            return _zombie;
        }
    }

    public enum EnemyType
    {
        Zombie
    }
}