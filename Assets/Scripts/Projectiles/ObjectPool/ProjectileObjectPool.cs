using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ProjectileObjectPool : ObjectPool<Projectile>, IProjectileReclaimer
{
    private ProjectileFactory _factory;
    private ProjectileType _type;

    public ProjectileObjectPool(ProjectileFactory factory, ProjectileType type, int initialSize)
        : base(() => factory.Get(type), initialSize)
    {
        _factory = factory;
        _type = type;
    }

    protected override Projectile AddObjectToPool()
    {
        Projectile projectile = _factory.Get(_type);
        projectile.ProjectileReclaimer = this;
        projectile.gameObject.SetActive(false);
        _pool.Add(projectile);
        return projectile;
    }
}
