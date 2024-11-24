using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace GamePlay.Enemies
{
    public class EnemiesContainer : MonoBehaviour
    {
        [Inject] private EnemyFactory _enemyFactory;

        private List<Enemy> _enemies = new();

        public Enemy Spawn(EnemyContext enemyContext, EnemyType type)
        {
            var enemy = _enemyFactory.Create(type, enemyContext);
            _enemies.Add(enemy);
            return enemy;
        }

        public void Clear()
        {
            _enemies.ForEach(e => Destroy(e.gameObject));
            _enemies.Clear();
        }
    }
}