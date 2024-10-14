using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChunkSpawner : MonoBehaviour
{
    [SerializeField] private LevelConfig _levelConfig;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private ChunkObjectPoolHolder _chunkObjectPool;
    [SerializeField] private Car _car;

    private List<Chunk> _activeChunks = new List<Chunk>();
    private int _spawnedChunksCount;

    public void Enable()
    {
        _car.CarReachedChunk += TrySpawnChunk;
    }

    public void Disable() 
    {
        _car.CarReachedChunk -= TrySpawnChunk;
    }   

    public void TrySpawnChunk()
    {
        if (_spawnedChunksCount >= _levelConfig.LevelLength)
        {
            RemoveLastChunk();
            SpawnLastChunk();
            return;
        }

        SpawnRandomChunk();

        if(_activeChunks.Count > 2)
        {
            RemoveLastChunk();
        }
    }


    public InitialChunk SpawnInitialChunk()
    {
        var chunk = _chunkObjectPool.Pool.GetInitialChunk();
        _activeChunks.Add(chunk);
        return chunk;
    }

    private void SpawnLastChunk()
    {
        var chunk = _chunkObjectPool.Pool.GetEndChunk();
        chunk.ChangeTransformBasedOnPreviousChunk(_activeChunks.Last());
        _activeChunks.Add(chunk);
    }

    public void SpawnRandomChunk()
    {
        var chunk = _chunkObjectPool.Pool.Get();
        chunk.ChangeTransformBasedOnPreviousChunk(_activeChunks.Last());
        chunk.SpawnEnemiesOnChunk(_enemySpawner, _levelConfig.EnemiesPerChunk.RandomValueInRange);

        _activeChunks.Add(chunk);
        _spawnedChunksCount++;
    }

    private void RemoveLastChunk()
    {
        var chunk = _activeChunks[0];
        chunk.Recycle();
        _activeChunks.RemoveAt(0);
    }

    public void Clear()
    {
        _spawnedChunksCount = 0;
        foreach (var chunk in _activeChunks)
        {
            chunk.Recycle();
        }
        _activeChunks.Clear();
    }
}
