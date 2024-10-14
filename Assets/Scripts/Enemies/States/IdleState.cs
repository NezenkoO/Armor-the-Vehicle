using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if(other.TryGetComponent(out Car car))
        {
            _attackState.SetTarget(car.transform);
            _stateSwitcher.SwitchState<AttackState>();
        }
    }
}
