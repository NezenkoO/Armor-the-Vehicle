﻿using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Utils
{
    [Serializable]
    public struct FloatRange
    {
        [SerializeField] private float _min, _max;

        public float Min => _min;
        public float Max => _max;

        public float RandomValueInRange => Random.Range(_min, _max);

        public FloatRange(float value)
        {
            _min = _max = value;
        }

        public FloatRange(float min, float max)
        {
            _min = min;
            _max = max;
        }
    }

    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public class FloatRangeSliderAttribute : PropertyAttribute
    {
        public float Min { get; private set; }
        public float Max { get; private set; }

        public FloatRangeSliderAttribute(float min, float max)
        {
            Min = min;
            Max = max < min ? min : max;
        }
    }
}