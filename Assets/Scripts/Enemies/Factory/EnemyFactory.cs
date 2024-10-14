using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnityEngine.EventSystems.EventTrigger;

public abstract class EnemyFactory : GameObjectFactory, IEnemyReclaimer
{
    public Enemy Get(EnemyType type)
    {
        var config = GetConfig(type);
        Enemy instance = CreateGameObjectInstance(config.Prefab);
        instance.EnemyReclaimer = this;
        instance.Initialize(config.ToContext());
        return instance;
    }

    protected abstract EnemyConfig GetConfig(EnemyType type);

    public void Reclaim(Enemy enemy)
    {
        Destroy(enemy.gameObject);
    }
}
