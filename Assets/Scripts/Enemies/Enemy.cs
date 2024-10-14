using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[SelectionBase]
public class Enemy : GameBehaviorStateSwitcher
{
    public float Health { get; private set; }
    public float Damage { get; private set; }
    public IEnemyReclaimer EnemyReclaimer { get; set; }

    [SerializeField] private EnemyMover _enemyMovement;
    [SerializeField] private EnemyView _enemyView;
    [SerializeField] private EnemyHud _enemyHud;

    private EnemyContext _context;

    public void Initialize(EnemyContext context)
    {
        Health = context.Health;
        Damage = context.Damage;

        transform.rotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
        transform.localScale = new Vector3(context.Scale, context.Scale, context.Scale);

        _enemyMovement.SetSpeed(context.Speed, context.RotationSpeed);
        _enemyHud.Initialize(Health);
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
        _enemyHud.ChangeHealth(Health);
        _enemyView.TakeDamageAnimation();
    }

    public override void Recycle()
    {
        if (EnemyReclaimer == null)
        {
            Debug.LogWarning("EnemyReclaimer is Null");
            Destroy(gameObject);
            return;
        }
        EnemyReclaimer.Reclaim(this);
    }

    public override void SetPaused(bool isPaused)
    {
        _enemyMovement.enabled = !isPaused;
    }

    public void ResetEnemy()
    {
        Initialize(_context);
        SwitchState<IdleState>();
    }
}
