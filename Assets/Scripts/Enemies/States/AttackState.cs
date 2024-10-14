using System.Collections;
using UnityEngine;

public class AttackState : State
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private EnemyMover _mover;
    [SerializeField] private EnemyView _enemyAnimations;

    private Transform _target;

    private void OnEnable()
    {
        _enemyAnimations.StartRunAnimation();
        _mover.MoveTowards(_target);
    }

    private void OnDisable()
    {
        _enemyAnimations.StopRunAnimation();
        _mover.Stop();
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out Car car))
        {
            _enemy.Recycle();
        }
    }
}
