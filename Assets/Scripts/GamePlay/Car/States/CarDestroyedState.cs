using UnityEngine;
using Core.State;

namespace GamePlay
{
    public class CarDestroyedState : State
    {
        [SerializeField] private CarMovement _carMovement;
        [SerializeField] private TurretBulletLauncher _turretBulletLauncher;
        [SerializeField] private TurretMovement _turretMovement;
        [SerializeField] private ParticleSystem _fireParticleSystem;

        private void OnEnable()
        {
            _fireParticleSystem.Play();
            _turretBulletLauncher.Clear();
            _turretBulletLauncher.enabled = false;
            _turretMovement.enabled = false;
            _carMovement.enabled = false;
        }

        private void OnDisable()
        {
            _fireParticleSystem.Clear();
            _fireParticleSystem.Stop();
        }
    }
}