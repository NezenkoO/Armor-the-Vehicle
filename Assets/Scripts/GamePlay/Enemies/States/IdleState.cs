using UnityEngine;
using Core.State;

namespace GamePlay
{
    public class IdleState : State
    {
        [SerializeField] private EnemyView _enemyAnimations;
        [SerializeField] private AttackState _attackState;

        public void OnEnable()
        {
            _enemyAnimations.StartIdleAnimation();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Car car))
            {
                _attackState.SetTarget(car.transform);
                _stateSwitcher.SwitchState<AttackState>();
            }
        }
    }
}