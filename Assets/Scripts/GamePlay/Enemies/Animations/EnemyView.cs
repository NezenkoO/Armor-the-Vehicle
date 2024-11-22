using System;
using UnityEngine;

namespace GamePlay.Enemy
{
    public abstract class EnemyView : MonoBehaviour
    {
        public Enemy Enemy { get; private set; }

        public void Init(Enemy enemy)
        {
            Enemy = enemy;
            OnInit();
        }

        public abstract void ApplyDamage(float value);
        public abstract void Die();
        protected virtual void OnInit() { }
    }
}