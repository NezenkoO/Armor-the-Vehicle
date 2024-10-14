using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class ProjectileConfig
{
    public Projectile Prefab;
    public float Speed;
    public float Damage;
    public float MaxAge;

    public ProjectileContext ToContext()
    {
        return new ProjectileContext(Speed, Damage, MaxAge);
    }
}
