using UnityEngine;
using GamePlay.Enemies;
using Core.Health;

namespace GamePlay.Projectiles
{
    public class Bullet : Projectile
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private TrailRenderer _trailRenderer;

        private float _age;

        public override void OnInitialize()
        {
            _age = 0;
            transform.rotation = Quaternion.LookRotation(Context.LaunchDirection, Vector3.up);
            _trailRenderer.Clear();
        }

        private void Update()
        {
            if (!IsInitialized)
                return;

            _age += Time.deltaTime;
            if (_age >= Context.MaxAge)
            {
                Destroy(gameObject);
                return;
            }

            rb.MovePosition(rb.position + Context.LaunchDirection.normalized * Context.Speed);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(Context.Damage);
            }

            Destroy(gameObject);
        }
    }
}
