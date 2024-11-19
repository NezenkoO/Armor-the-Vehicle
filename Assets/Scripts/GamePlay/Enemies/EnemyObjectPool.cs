using UnityEngine;
using UnityEngine.Pool;

namespace GamePlay
{
    public class EnemyObjectPool : MonoBehaviour
    {
        [SerializeField] private EnemyType _type;
        [SerializeField] private EnemyFactory _enemyFactory;

        private ObjectPool<Enemy> _enemiesPool;

        private void Awake()
        {
            _enemiesPool = new ObjectPool<Enemy>(CreateProjectile, OnGetProjectile, Reclaim, OnDestroyProjectile, false, 10, 50);
        }

        public Enemy Get() => _enemiesPool.Get();

        public void Clear()
        {
            _enemiesPool.Clear();
        }

        public void Reclaim(Enemy projectile)
        {
            projectile.gameObject.SetActive(false);
        }

        private Enemy CreateProjectile()
        {
            var projectile = _enemyFactory.Get(_type);
            projectile.gameObject.SetActive(false);
            return projectile;
        }

        private void OnGetProjectile(Enemy projectile)
        {
            projectile.gameObject.SetActive(true);
        }

        private void OnDestroyProjectile(Enemy projectile)
        {
            Destroy(projectile);
        }
    }
}