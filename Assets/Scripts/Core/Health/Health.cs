using GamePlay;
using System;
using UnityEngine;

namespace Core.Health
{
    public class Health : MonoBehaviour, IHealth
    {
        public event Action<int> HealthChanged;
        public event Action Died;

        public int Value { get; private set; }

        public void Initialize(int health)
        {
            Value = health;
        }

        public void TakeDamage(int damage)
        {
            if (damage <= 0) return;

            Value = Mathf.Max(Value - damage, 0);
            HealthChanged?.Invoke(Value);

            if (Value <= 0)
                Died?.Invoke();
        }

        public void Heal(int amount, int maxHealth)
        {
            if (amount <= 0) return;

            Value = Mathf.Min(Value + amount, maxHealth);
            HealthChanged?.Invoke(Value);
        }
    }
}