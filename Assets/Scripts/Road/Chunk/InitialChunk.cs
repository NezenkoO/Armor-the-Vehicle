using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class InitialChunk : Chunk
{
    public Transform CarPositionPoint => _carPositionPoint;

    [SerializeField] private Transform _carPositionPoint;
}
