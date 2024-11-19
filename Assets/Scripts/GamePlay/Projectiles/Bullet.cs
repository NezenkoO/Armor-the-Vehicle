using UnityEngine;

namespace GamePlay
{
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

        public void Update()
        {
            if (_direction == Vector3.zero)
                return;

            _age += Time.deltaTime;
            if (_age >= _maxAge)
            {
                Recycle();
                return;
            }

            rb.MovePosition(rb.position + _direction.normalized * Speed);
            return;
        }

        public void Recycle()
        {
            if (ProjectileReclaimer == null)
            {
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
    }
}