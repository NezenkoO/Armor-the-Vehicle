using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Enemy
{
    public class EnemiesSpawner : MonoBehaviour
    {
        [SerializeField] private EnemyFactory _enemyFactory;

        private List<Enemy> _enemies = new();

        public Enemy SpawnZombie(EnemyContext enemyContext)
        {
            var enemy = _enemyFactory.Create(EnemyType.Zombie);
            enemy.Initialize(enemyContext);
            _enemies.Add(enemy);
            return enemy;
        }

        public void Clear()
        {
            _enemies.ForEach(e => e.Die());
            _enemies.Clear();
        }
    }
}