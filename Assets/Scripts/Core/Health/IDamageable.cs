using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Health
{
    public interface IDamageable
    {
        public void TakeDamage(int damage);
    }
}
