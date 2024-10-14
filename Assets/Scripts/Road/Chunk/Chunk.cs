using System;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : GameBehavior
{
    public IChunkReclaimer ChunkReclaimer { get; set; }
    public Transform Begin => begin;
    public Transform End => end;

    [SerializeField] private Transform begin, end;

    public void ChangeTransformBasedOnPreviousChunk(Chunk previousChunk)
    {
        transform.position = previousChunk.Begin.position - End.localPosition;
    }

    public virtual void SpawnEnemiesOnChunk(EnemySpawner enemiesSpawner, int count)
    {
        Vector3 roadDirection = (end.position - begin.position).normalized;
        float roadLength = Vector3.Distance(begin.position, end.position);

        for (int i = 0; i < count; i++)
        {
            float randomDistance = UnityEngine.Random.Range(0f, roadLength);
            Vector3 enemyPosition = begin.position + roadDirection * randomDistance;

            Vector3 roadWidthOffset = Vector3.right * UnityEngine.Random.Range(-5f, 5f);
            enemyPosition += roadWidthOffset;

            var enemy = enemiesSpawner.SpawnEnemy();
            enemy.transform.position = enemyPosition;
        }
    }

    public override void Recycle()
    {
        if (ChunkReclaimer == null)
        {
            Debug.LogWarning("ChunkReclaimer is Null");
            Destroy(gameObject);
            return;
        }
        ChunkReclaimer.Reclaim(this);
    }
}
