using System.Collections.Generic;
using UnityEngine;
using Core;

namespace GamePlay
{
    [CreateAssetMenu(fileName = "ChunkFactory", menuName = "Factories/ChunkFactory")]
    public class ChunkFactory : GameObjectFactory
    {
        public IReadOnlyList<StraightChunk> StraightChunks => _straightChunks;

        [SerializeField] private SetupChunk _setupChunk;
        [SerializeField] private FinishChunk _finishChunk;
        [SerializeField] private List<StraightChunk> _straightChunks;

        public SetupChunk GetSetupChunk()
        {
            var chunk = CreateGameObjectInstance(_setupChunk);
            return chunk;
        }

        public FinishChunk GetFinishChunk()
        {
            var chunk = CreateGameObjectInstance(_finishChunk);
            return chunk;
        }

        public Chunk GetRandomStraightChunk()
        {
            if (_straightChunks == null || _straightChunks.Count == 0)
            {
                Debug.LogError("Chunk list is empty!");
                return _setupChunk;
            }

            int randomIndex = Random.Range(0, _straightChunks.Count);
            var chunk = CreateGameObjectInstance(_straightChunks[randomIndex]);
            return chunk;
        }
    }
}
