using UnityEngine;

namespace GamePlay.Enemy
{
    public abstract class EnemyMovement : MonoBehaviour
    {
        [SerializeField] protected Rigidbody _rigidbody;
        [SerializeField] protected EnemyView _enemyView;

        public float RotationSpeed { get; private set; }
        public float Speed { get; private set; }

        public void Initialize(float speed, float rotationSpeed)
        {
            if (speed < 0 || rotationSpeed < 0)
                Debug.LogError("Speed cant be less than zero");

            Speed = speed;
            RotationSpeed = rotationSpeed;
        }

        public abstract void Run(Vector3 to);
    }
}