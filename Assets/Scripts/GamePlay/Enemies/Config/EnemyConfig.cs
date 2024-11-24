using System;
using UnityEngine;
using Utils;

namespace GamePlay.Enemies
{
    [Serializable]
    public class EnemyConfig
    {
        [field: SerializeField, FloatRangeSlider(0.1f, 2f)] public FloatRange Scale { get; private set; }
        [field: SerializeField, FloatRangeSlider(1f, 20f)] public FloatRange Speed { get; private set; }
        [field: SerializeField, FloatRangeSlider(1f, 20f)] public FloatRange RotationSpeed { get; private set; }
        [field: SerializeField, IntRangeSlider(10, 1000)] public IntRange Health { get; private set; }
        [field: SerializeField, IntRangeSlider(1, 100)] public IntRange Damage { get; private set; }

        public EnemyContext ToContext()
        {
            return new EnemyContext(
                Scale.RandomValueInRange,
                Speed.RandomValueInRange,
                RotationSpeed.RandomValueInRange,
                Health.RandomValueInRange,
                Damage.RandomValueInRange
            );
        }
    }
}