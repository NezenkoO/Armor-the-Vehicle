using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDriveState : State
{
    [SerializeField] private TurretMovement _turretMovement;
    [SerializeField] private TurretBulletLauncher _turretBulletLauncher;
    [SerializeField] private CarMovement _carMovement;
    [SerializeField] private ParticleSystem _smokeParticleSystem;
    [SerializeField] private LineRenderer _lineRenderer;

    private void OnEnable()
    {
        _lineRenderer.enabled = true;
        _turretMovement.enabled = true;
        _turretBulletLauncher.enabled = true;
        _carMovement.enabled = true;
        _smokeParticleSystem.Play();
    }

    private void OnDisable()
    {
        _lineRenderer.enabled = false;
        _smokeParticleSystem.Stop();
    }
}
