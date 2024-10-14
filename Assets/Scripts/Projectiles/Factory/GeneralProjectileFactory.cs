using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "GeneralProjectileFactory", menuName = "Factories/Projectile/General")]
public class GeneralProjectileFactory : ProjectileFactory
{
    [SerializeField] private ProjectileConfig _bullet;

    protected override ProjectileConfig GetConfig(ProjectileType type)
    {
        switch (type)
        {
            case ProjectileType.Bullet:
                return _bullet;
        }
        Debug.LogError($"No Config for {type}");
        return _bullet;
    }
}
