﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class GameSetupState : State
{
    [SerializeField] private CameraStateSwitcher _cameraStateSwitcher;
    [SerializeField] private ChunkSpawner _chunkSpawner;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private Car _car;
    [SerializeField] private Turret _turret;
    [SerializeField] private SetupView _setupView;

    private void OnEnable()
    {
        _chunkSpawner.Clear();
        _enemySpawner.Clear();
        var initialChunk = _chunkSpawner.SpawnInitialChunk();

        _cameraStateSwitcher.SwitchState<SideCameraViewState>();
        _car.SwitchState<CarInactiveState>();
        _car.Initialize();
        _turret.ResetRotation();
        _car.transform.position = initialChunk.CarPositionPoint.position;
        _setupView.Show();
        _setupView.GoButtonClicked += OnGoButtonClick;
    }

    private void OnDisable()
    {
        _setupView.GoButtonClicked -= OnGoButtonClick;
        _setupView.Hide();
    }


    private void OnGoButtonClick()
    {
        _stateSwitcher.SwitchState<GamePlayState>();
    }
}
