using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Bullet : Projectile
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private TrailRenderer _trailRenderer;

    private Vector3 _direction;
    private float _age;

    public override void Launch(Vector3 direction)
    {
        _age = 0;
        _direction = direction;
        transform.rotation = Quaternion.LookRotation(_direction, Vector3.up);
        _trailRenderer.Clear();
    }

    public override bool GameUpdate()
    {
        if (_direction == Vector3.zero) 
            return true;

        _age += Time.deltaTime;
        if(_age >= _maxAge)
        {
            Recycle();
            return false;
        }

        rb.MovePosition(rb.position + _direction.normalized * Speed);
        return true;
    }

    public override void Recycle()
    {
        if (ProjectileReclaimer == null)
        {
            Debug.LogWarning("ProjectileReclaimer is null");
            Destroy(gameObject);
            return;
        }
        ProjectileReclaimer.Reclaim(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.DealDamage(Damage);
            Recycle();
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.TryGetComponent(out Enemy enemy))
    //    {
    //        enemy.DealDamage(Damage);
    //    }
    //    Recycle();
    //}
}
