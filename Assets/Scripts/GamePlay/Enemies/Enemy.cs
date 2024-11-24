using Core.Health;
using Core.State;
using Core.UI;
using UnityEngine;
using Utils;

namespace GamePlay.Enemies
{
    [SelectionBase]
    public class Enemy : StateSwitcher
    {
        public EnemyContext Context { get; private set; }
        public IHealth Health => _healthLinkedInterface.Value;

        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private EnemyView _enemyView;
        [SerializeField] private HealthView _healthView;
        [SerializeField] private LinkedInterface<IHealth> _healthLinkedInterface;

        public void Initialize(EnemyContext context)
        {
            Context = context;

            transform.localScale = Vector3.one * context.Scale;

            Health.Initialize(context.Health);
            _healthView.Initialize(Health);
            _enemyView.Initialize(this);
            _enemyMovement.Initialize(context.Speed, context.RotationSpeed);
            OnInitialize();
        }

        private void OnEnable()
        {
            Health.HealthChanged += OnHealthChanged;
            Health.Died += Die;
        }

        private void OnDisable()
        {
            Health.HealthChanged -= OnHealthChanged;
            Health.Died -= Die;
        }

        private void OnHealthChanged(int currentHealth)
        {
            _enemyView.PlayTakeDamageAnimation(currentHealth);
        }

        public void Die()
        {
            OnDie();
            _enemyView.PlayDieAnimation();
            Destroy(gameObject);
        }

        public virtual void OnDie() { }
        public virtual void OnInitialize() { }
    }
}