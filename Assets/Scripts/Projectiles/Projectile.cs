using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class Projectile : GameBehavior
{
    public float Damage { get; protected set; }
    public float Speed { get; protected set; }

    protected float _maxAge;

    public IProjectileReclaimer ProjectileReclaimer { get; set; }

    public void Initialize(ProjectileContext projectileConfig)
    {
        Damage = projectileConfig.Damage;
        Speed = projectileConfig.Speed;
        _maxAge = projectileConfig.MaxAge;
    }

    public abstract void Launch(Vector3 direction);
}
