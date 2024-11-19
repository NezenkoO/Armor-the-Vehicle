using UnityEngine;
using UnityEngine.Pool;

namespace GamePlay
{
    public class ChunkObjectPool : MonoBehaviour, IChunkReclaimer
    {
        [SerializeField] private ChunkFactory _chunkFactory;

        private ObjectPool<Chunk> _straightChunksPool;
        private ObjectPool<FinishChunk> _endChunksPool;
        private ObjectPool<SetupChunk> _initialChunksPool;

        private void Awake()
        {
            _straightChunksPool = new ObjectPool<Chunk>(CreateStraightChunk, OnGetChunk, Reclaim, OnDestroyChunk, false, 3);
            _endChunksPool = new ObjectPool<FinishChunk>(CreateEndChunk, OnGetChunk, Reclaim, OnDestroyChunk, false, 1);
            _initialChunksPool = new ObjectPool<SetupChunk>(CreateInitialChunk, OnGetChunk, Reclaim, OnDestroyChunk, false, 1);
        }

        public Chunk GetRandomStraightChunk() => _straightChunksPool.Get();
        public FinishChunk GetFinishChunk() => _endChunksPool.Get();
        public SetupChunk GetSetupChunk() => _initialChunksPool.Get();

        public void Clear()
        {
            _straightChunksPool.Clear();
            _endChunksPool.Clear();
            _initialChunksPool.Clear();
        }

        public void Reclaim(Chunk chunk)
        {
            chunk.gameObject.SetActive(false);
        }

        private Chunk CreateStraightChunk()
        {
            var chunk = _chunkFactory.GetRandomStraightChunk();
            chunk.ChunkReclaimer = this;
            chunk.gameObject.SetActive(false);
            return chunk;
        }

        private FinishChunk CreateEndChunk()
        {
            var chunk = _chunkFactory.GetFinishChunk();
            chunk.gameObject.SetActive(false);
            return chunk;
        }

        private SetupChunk CreateInitialChunk()
        {
            var chunk = _chunkFactory.GetSetupChunk();
            chunk.gameObject.SetActive(false);
            return chunk;
        }

        private void OnGetChunk(Chunk chunk)
        {
            chunk.gameObject.SetActive(true);
        }

        private void OnDestroyChunk(Chunk chunk)
        {
            Destroy(chunk.gameObject);
        }
    }
}
