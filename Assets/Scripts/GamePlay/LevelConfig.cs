using UnityEngine;
using Utils;

namespace GamePlay
{
    [CreateAssetMenu]
    public class LevelConfig : ScriptableObject
    {
        public int LevelLength;
        [IntRangeSlider(0, 80)]
        public IntRange EnemiesPerChunk;
    }
}