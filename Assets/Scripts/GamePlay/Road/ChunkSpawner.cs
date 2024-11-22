using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using GamePlay.Enemy;

namespace GamePlay
{
    public class ChunkSpawner : MonoBehaviour
    {
        [SerializeField] private LevelConfig _levelConfig;
        [SerializeField] private EnemiesSpawner _enemySpawner;
        [SerializeField] private ChunkObjectPool _chunkObjectPool;
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

            if (_activeChunks.Count > 2)
            {
                RemoveLastChunk();
            }
        }


        public SetupChunk SpawnInitialChunk()
        {
            var chunk = _chunkObjectPool.GetSetupChunk();
            _activeChunks.Add(chunk);
            return chunk;
        }

        private void SpawnLastChunk()
        {
            var chunk = _chunkObjectPool.GetFinishChunk();
            chunk.ChangeTransformBasedOnPreviousChunk(_activeChunks.Last());
            _activeChunks.Add(chunk);
        }

        public void SpawnRandomChunk()
        {
            var chunk = _chunkObjectPool.GetRandomStraightChunk();
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
}
