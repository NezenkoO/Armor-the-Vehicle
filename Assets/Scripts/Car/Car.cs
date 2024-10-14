using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Car : GameBehaviorStateSwitcher
{
    public event Action CarDestroyed;
    public event Action<EndChunk> CarReachedEndChunk;
    public event Action CarReachedChunk;
    public float Health { get; private set; }

    [SerializeField] private float _startHealth;
    [SerializeField] private CarView _carAnimation;
    [SerializeField] private CarHud _hud;

    public void Initialize()
    {
        Health = _startHealth;
        _hud.Initialize(_startHealth);
    }

    public void DealDamage(float value)
    {
        Health -= value;
        if (Health <= 0)
        {
            _hud.Hide();
            CarDestroyed?.Invoke();
            return;
        }
        _hud.ChangeHealth(Health);
        _carAnimation.PlayHitAnimation();
    }

    public override void Recycle()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            DealDamage(enemy.Damage);
            enemy.Recycle();
        }
        else if(other.TryGetComponent(out EndChunk endChunk))
        {
            CarReachedEndChunk?.Invoke(endChunk);
        }
        else if (other.TryGetComponent(out Chunk chunk))
        {
            CarReachedChunk?.Invoke();
        }
    }
}
