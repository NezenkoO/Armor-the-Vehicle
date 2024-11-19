using UnityEngine;

namespace GamePlay
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyObjectPool _enemyObjectPool;

        public Enemy SpawnEnemy()
        {
            var enemy = _enemyObjectPool.Get();
            return enemy;
        }

        public void Clear()
        {
            _enemyObjectPool.Clear();
        }
    }
}
