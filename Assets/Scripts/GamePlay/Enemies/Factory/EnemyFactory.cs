using Core;
using System;
using UnityEngine;
using Zenject;

namespace GamePlay.Enemies
{
    [CreateAssetMenu(fileName = "EnemyFactory", menuName = "Factories/EnemyFactory")]
    public class EnemyFactory : ScriptableObject
    {
        [SerializeField] private Enemy _zombie;

        private DiContainer _diContainer;

        [Inject]
        public void Initialize(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public Enemy Create(EnemyType type, EnemyContext context)
        {
            var enemy = type switch
            {
                EnemyType.Zombie => _diContainer.InstantiatePrefabForComponent<Enemy>(_zombie),
                _ => throw new NotImplementedException($"EnemyType {type} is not implemented."),
            };

            enemy.Initialize(context);
            return enemy;
        }
    }

    public enum EnemyType
    {
        Zombie
    }
}