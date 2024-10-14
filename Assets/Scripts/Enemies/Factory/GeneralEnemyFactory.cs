using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "GeneralEnemyFactory", menuName = "Factories/Enemy/General")]
public class GeneralEnemyFactory : EnemyFactory
{
    [SerializeField] private EnemyConfig _zombie;

    protected override EnemyConfig GetConfig(EnemyType type)
    {
        switch (type)
        {
            case EnemyType.Zombie:
                return _zombie;
        }
        Debug.LogError($"No config for: {type}");
        return _zombie;
    }
}
