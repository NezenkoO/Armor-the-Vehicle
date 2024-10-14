using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, IPauseHandler
{
    [SerializeField] private EnemyObjectPoolHolder _enemyObjectPool;

    private GameBehaviorCollection _enemiesGameBehaviorCollection = new GameBehaviorCollection();

    private void Update()
    {
        _enemiesGameBehaviorCollection.GameUpdate();
    }

    public Enemy SpawnEnemy()
    {
        var enemy = _enemyObjectPool.Pool.Get();
        _enemiesGameBehaviorCollection.Add(enemy);
        return enemy;
    }

    public void SetPaused(bool isPaused)
    {
        _enemiesGameBehaviorCollection.SetPaused(isPaused);
    }

    public void Clear()
    {
        _enemiesGameBehaviorCollection.Clear();
    }
}
