using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChunkFactory", menuName = "Factories/ChunkFactory")]
public class ChunkFactory : GameObjectFactory, IChunkReclaimer
{
    [SerializeField] private InitialChunk _initialChunk;
    [SerializeField] private EndChunk _endChunk;
    [SerializeField] private List<Chunk> _chunks;

    public InitialChunk GetInitialChunk()
    {
        var chunk = CreateGameObjectInstance(_initialChunk);
        chunk.ChunkReclaimer = this;
        return chunk;
    }

    public EndChunk GetEndChunk()
    {
        var chunk = CreateGameObjectInstance(_endChunk);
        chunk.ChunkReclaimer = this;
        return chunk;
    }

    public Chunk GetRandomChunk()
    {
        if (_chunks == null || _chunks.Count == 0)
        {
            Debug.LogError("Chunk list is empty!");
            return _initialChunk;
        }

        int randomIndex = Random.Range(0, _chunks.Count);
        var chunk = CreateGameObjectInstance(_chunks[randomIndex]);
        chunk.ChunkReclaimer = this;
        return chunk;
    }

    public void Reclaim(Chunk chunk)
    {
        Destroy(chunk.gameObject);
    }
}
