using UnityEngine;
using Core.State;
using Core.UI;

namespace GamePlay
{
    [SelectionBase]
    public class Enemy : StateSwitcher
    {
        public float Health { get; private set; }
        public float Damage { get; private set; }
        public IEnemyReclaimer EnemyReclaimer { get; set; }

        [SerializeField] private EnemyMover _enemyMovement;
        [SerializeField] private EnemyView _enemyView;
        [SerializeField] private HealthBar _enemyHud;

        private EnemyContext _context;

        public void Initialize(EnemyContext context)
        {
            Health = context.Health;
            Damage = context.Damage;

            transform.rotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
            transform.localScale = new Vector3(context.Scale, context.Scale, context.Scale);

            _enemyMovement.SetSpeed(context.Speed, context.RotationSpeed);
            _enemyHud.Initialize(Health);
            _enemyHud.Hide();
            _context = context;
        }

        public void DealDamage(float value)
        {
            Health -= value;
            if (Health <= 0)
            {
                Recycle();
                return;
            }
            _enemyHud.Show();
            _enemyHud.ChangeHealth(Health);
            _enemyView.TakeDamageAnimation();
        }

        public void Recycle()
        {
            if (EnemyReclaimer == null)
            {
                Destroy(gameObject);
                return;
            }
            EnemyReclaimer.Reclaim(this);
        }

        public void ResetEnemy()
        {
            Initialize(_context);
            SwitchState<IdleState>();
        }
    }
}
