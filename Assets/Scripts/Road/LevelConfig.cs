using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu]
public class LevelConfig : ScriptableObject
{
    public int LevelLength;
    [IntRangeSlider(0, 80)]
    public IntRange EnemiesPerChunk;
}
