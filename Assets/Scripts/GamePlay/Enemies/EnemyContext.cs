﻿namespace GamePlay.Enemy
{
    public readonly struct EnemyContext
    {
        public float Scale { get; }
        public float Speed { get; }
        public float RotationSpeed { get; }
        public float Health { get; }
        public int Damage { get; }

        public EnemyContext(float scale, float speed, float rotationSpeed, float health, int damage)
        {
            Scale = scale;
            Speed = speed;
            RotationSpeed = rotationSpeed;
            Health = health;
            Damage = damage;
        }
    }
}