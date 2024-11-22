using Core.State;
using UnityEngine;
using Zenject;

namespace GamePlay.Enemy
{
    [SelectionBase]
    public class Enemy : StateSwitcher
    {
        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private EnemyView _enemyView;

        public float CurrentHealth { get; private set; }
        public EnemyContext Context { get; private set; }

        public void Initialize(EnemyContext context)
        {
            CurrentHealth = context.Health;
            Context = context;

            transform.rotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
            transform.localScale = Vector3.one * context.Scale;

            _enemyView.Init(this);
            _enemyMovement.Initialize(context.Speed, context.RotationSpeed);
        }

        public void TakeDamage(float value)
        {
            if ((CurrentHealth -= value) <= 0) Die();
            else _enemyView.ApplyDamage(value);
        }

        public void Die()
        {
            _enemyView.Die();
            Destroy(gameObject);
        }

        public class Factory : PlaceholderFactory<Enemy> { }
    }
}
