using Core.State;
using Core.UI;
using UnityEngine;

namespace GamePlay
{
    public class CarInactiveState : State
    {
        [SerializeField] private HealthView _hud;
        [SerializeField] private CarMovement _carMovement;
        [SerializeField] private TurretBulletLauncher _turretBulletLauncher;
        [SerializeField] private TurretMovement _turretMovement;

        private void OnEnable()
        {
            //_hud.Hide();
            //_turretBulletLauncher.Clear();
            _turretBulletLauncher.enabled = false;
            _turretMovement.enabled = false;
            _carMovement.enabled = false;
        }
    }
}
