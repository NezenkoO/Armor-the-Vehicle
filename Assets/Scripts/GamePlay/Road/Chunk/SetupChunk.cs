using UnityEngine;

namespace GamePlay
{
    public class SetupChunk : Chunk
    {
        public Transform CarPositionPoint => _carPositionPoint;

        [SerializeField] private Transform _carPositionPoint;
    }
}
