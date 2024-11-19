using UnityEngine;

namespace GamePlay
{
    public class EnemyMover : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;

        private float _rotationSpeed;
        private float _speed;
        private Transform _target;

        public void SetSpeed(float speed, float rotationSpeed)
        {
            if (speed < 0 || rotationSpeed < 0)
                Debug.LogError("Speed cant be less than zero");

            _speed = speed;
            _rotationSpeed = rotationSpeed;
        }

        private void Update()
        {
            if (_target == null) return;

            Vector3 direction = (_target.position - transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            _rigidbody.MoveRotation(Quaternion.Lerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime));

            Vector3 forwardMovement = transform.forward * _speed * Time.deltaTime;
            _rigidbody.MovePosition(_rigidbody.position + forwardMovement);
        }

        public void MoveTowards(Transform target)
        {
            _target = target;
        }

        public void Stop()
        {
            _target = null;
        }
    }
}