using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ChunkObjectPoolHolder : MonoBehaviour
{
    public ChunkObjectPool Pool { get; private set; }

    [SerializeField] private ChunkFactory _chunkFactory;
    [SerializeField] private int _initialSize;

    private void Awake()
    {
        Pool = new ChunkObjectPool(_chunkFactory, _initialSize);
    }
}
