using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ChunkObjectPool : ObjectPool<Chunk>, IChunkReclaimer
{
    ChunkFactory _chunkFactory;

    public ChunkObjectPool(ChunkFactory chunkFactory, int initialSize) : base(() => chunkFactory.GetRandomChunk(), initialSize)
    {
        _chunkFactory = chunkFactory;
    }

    protected override Chunk AddObjectToPool()
    {
        var chunk = _chunkFactory.GetRandomChunk();
        chunk.ChunkReclaimer = this;
        chunk.gameObject.SetActive(false);
        _pool.Add(chunk);
        return chunk;
    }

    public InitialChunk GetInitialChunk()
    {
        return _chunkFactory.GetInitialChunk();
    }

    public EndChunk GetEndChunk()
    {
        return _chunkFactory.GetEndChunk();
    }
}
