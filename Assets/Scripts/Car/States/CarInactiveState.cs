using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CarInactiveState : State
{
    [SerializeField] private CarHud _hud;
    [SerializeField] private CarMovement _carMovement;
    [SerializeField] private TurretBulletLauncher _turretBulletLauncher;
    [SerializeField] private TurretMovement _turretMovement;

    private void OnEnable()
    {
        _hud.Hide();
        _turretBulletLauncher.Clear();
        _turretBulletLauncher.enabled = false;
        _turretMovement.enabled = false;
        _carMovement.enabled = false;
    }
} 
