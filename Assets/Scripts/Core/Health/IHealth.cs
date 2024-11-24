using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Health
{
    public interface IHealth
    {
        public int Value { get; }

        public event Action<int> HealthChanged;
        public event Action Died;

        public void Initialize(int health);

        public void TakeDamage(int damage);
    }
}