using UnityEngine;

namespace GamePlay.Road
{
    public class SetupChunk : Chunk
    {
        public Transform CarPositionPoint => _carPositionPoint;

        [SerializeField] private Transform _carPositionPoint;
    }
}
