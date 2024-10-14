using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class ProjectileFactory : GameObjectFactory, IProjectileReclaimer
{
    public Projectile Get(ProjectileType type)
    {
        var config = GetConfig(type);
        Projectile instance = CreateGameObjectInstance(config.Prefab);
        instance.ProjectileReclaimer = this;
        instance.Initialize(config.ToContext());
        return instance;
    }

    protected abstract ProjectileConfig GetConfig(ProjectileType type);

    public void Reclaim(Projectile enemy)
    {
        Destroy(enemy.gameObject);
    }
}
