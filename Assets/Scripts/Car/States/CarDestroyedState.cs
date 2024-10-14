using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CarDestroyedState : State
{
    [SerializeField] private CarMovement _carMovement;
    [SerializeField] private CarHud _hud;
    [SerializeField] private TurretBulletLauncher _turretBulletLauncher;
    [SerializeField] private TurretMovement _turretMovement;
    [SerializeField] private ParticleSystem _fireParticleSystem;

    private void OnEnable()
    {
        _hud.Hide();
        _fireParticleSystem.Play();
        _turretBulletLauncher.Clear();
        _turretBulletLauncher.enabled = false;
        _turretMovement.enabled = false;
        _carMovement.enabled = false;
    }

    private void OnDisable()
    {
        _fireParticleSystem.Stop();
    }
}
