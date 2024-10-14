﻿using System;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public struct IntRange
{
    [SerializeField] private int _min, _max;

    public int Min => _min;
    public int Max => _max;

    public int RandomValueInRange => Random.Range(_min, _max);

    public IntRange(int value)
    {
        _min = _max = value;
    }

    public IntRange(int min, int max)
    {
        _min = min;
        _max = max;
    }
}

public class IntRangeSliderAttribute : PropertyAttribute
{
    public int Min { get; private set; }
    public int Max { get; private set; }

    public IntRangeSliderAttribute(int min, int max)
    {
        Min = min;
        Max = max < min ? min : max;
    }
}
