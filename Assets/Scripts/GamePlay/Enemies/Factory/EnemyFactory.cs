using System;
using UnityEngine;
using Zenject;

namespace GamePlay.Enemy
{
    [CreateAssetMenu(fileName = "EnemyFactory", menuName = "Factories/EnemyFactory")]
    public class EnemyFactory : ScriptableObject
    {
        [SerializeField] private Enemy _zombie;

        [Inject]
        private readonly DiContainer _diContainer;

        public Enemy Create(EnemyType type)
        {
            return type switch
            {
                EnemyType.Zombie => _diContainer.InstantiatePrefabForComponent<Enemy>(_zombie),
                _ => throw new NotImplementedException($"EnemyType {type} is not implemented."),
            };
        }
    }

    public enum EnemyType
    {
        Zombie
    }
}