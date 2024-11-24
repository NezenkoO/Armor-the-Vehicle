using System.Collections.Generic;
using UnityEngine;
using Core;

namespace GamePlay.Road
{
    [CreateAssetMenu(fileName = "ChunkFactory", menuName = "Factories/ChunkFactory")]
    public class ChunkFactory : ScriptableObject
    {
        public IReadOnlyList<StraightChunk> StraightChunks => _straightChunks;

        [SerializeField] private SetupChunk _setupChunk;
        [SerializeField] private FinishChunk _finishChunk;
        [SerializeField] private List<StraightChunk> _straightChunks;

        public SetupChunk GetSetupChunk()
        {
            var chunk = Instantiate(_setupChunk);
            return chunk;
        }

        public FinishChunk GetFinishChunk()
        {
            var chunk = Instantiate(_finishChunk);
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
            var chunk = Instantiate(_straightChunks[randomIndex]);
            return chunk;
        }
    }
}
