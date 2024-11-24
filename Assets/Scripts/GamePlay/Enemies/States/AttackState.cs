using UnityEngine;
using Core.State;

namespace GamePlay.Enemies
{
    public class AttackState : State
    {
        [SerializeField] private EnemyMovement _mover;

        private Transform _target;

        private void Update()
        {
            _mover.Run(_target.position);
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }
    }
}