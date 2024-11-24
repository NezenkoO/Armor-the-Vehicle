using System;
using UnityEngine;
using Core.State;
using Core.UI;
using GamePlay.Road;

namespace GamePlay
{
    [SelectionBase]
    public class Car : StateSwitcher
    {
        public event Action CarDestroyed;
        public event Action<FinishChunk> CarReachedEndChunk;
        public event Action CarReachedChunk;
        public float Health { get; private set; }

        [SerializeField] private float _startHealth;
        [SerializeField] private CarView _carAnimation;
        [SerializeField] private HealthView _hud;

        public void Initialize()
        {
            //Health = _startHealth;
            //_hud.Initialize(_startHealth);
            //_hud.Hide();
        }

        public void DealDamage(float value)
        {
            //Health -= value;
            //if (Health <= 0)
            //{
            //    _hud.Hide();
            //    CarDestroyed?.Invoke();
            //    return;
            //}
            //_hud.Show();
            //_hud.ChangeHealth(Health);
            //_carAnimation.PlayHitAnimation();
        }

        public void Recycle()
        {
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            //if (other.TryGetComponent(out Enemy enemy))
            //{
            //    DealDamage(enemy.Context.Damage);
            //    enemy.Recycle();
            //}
            //else if (other.TryGetComponent(out FinishChunk endChunk))
            //{
            //    CarReachedEndChunk?.Invoke(endChunk);
            //}
            //else if (other.TryGetComponent(out Chunk chunk))
            //{
            //    CarReachedChunk?.Invoke();
            //}
        }
    }
}