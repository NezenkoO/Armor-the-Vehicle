using UnityEngine;
using Core.State;

namespace GamePlay.Enemy
{
    public class IdleState : State
    {
        [SerializeField] private AttackState _attackState;

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