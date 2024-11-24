using System;
using UnityEngine;

namespace GamePlay.Enemies
{
    public abstract class EnemyView : MonoBehaviour
    {
        public Enemy Enemy { get; private set; }

        public void Initialize(Enemy enemy)
        {
            Enemy = enemy;
            OnInit();
        }

        public abstract void PlayTakeDamageAnimation(float value);
        public abstract void PlayDieAnimation();
        protected virtual void OnInit() { }
    }
}