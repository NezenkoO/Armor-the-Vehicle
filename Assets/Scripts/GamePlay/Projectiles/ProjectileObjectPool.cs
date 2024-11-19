using UnityEngine;
using UnityEngine.Pool;

namespace GamePlay
{
    public class ProjectileObjectPool : MonoBehaviour, IProjectileReclaimer
    {
        [SerializeField] private ProjectileType _type;
        [SerializeField] private ProjectileFactory _projectilesFactory;

        private ObjectPool<Projectile> _projectilePool;

        private void Awake()
        {
            _projectilePool = new ObjectPool<Projectile>(CreateProjectile, OnGetProjectile, Reclaim, OnDestroyProjectile, false, 10, 50);
        }

        public Projectile Get() => _projectilePool.Get();

        public void ReleaseProjectile(Projectile projectile)
        {
            _projectilePool.Release(projectile);
        }

        public void Clear()
        {
            _projectilePool.Clear();
        }

        public void Reclaim(Projectile projectile)
        {
            projectile.gameObject.SetActive(false);
        }

        private Projectile CreateProjectile()
        {
            Projectile projectile = _projectilesFactory.Get(_type);
            projectile.gameObject.SetActive(false);
            return projectile;
        }

        private void OnGetProjectile(Projectile projectile)
        {
            projectile.gameObject.SetActive(true);
        }

        private void OnDestroyProjectile(Projectile projectile)
        {
            Destroy(projectile);
        }
    }
}
