using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GamePlayState : State
{
    [SerializeField] private CameraStateSwitcher _cameraStateSwitcher;
    [SerializeField] private ChunkSpawner _chunkSpawner;
    [SerializeField] private Car _car;

    private void OnEnable()
    {
        _chunkSpawner.Enable();
        _chunkSpawner.TrySpawnChunk();
        _car.SwitchState<CarDriveState>();
        _cameraStateSwitcher.SwitchState<BackCameraViewState>();
        _car.CarReachedEndChunk += CarReachedEndChunk;
        _car.CarDestroyed += OnCarDestroyed;
    }

    private void OnDisable()
    {
        _chunkSpawner.Disable();
        _car.CarReachedEndChunk -= CarReachedEndChunk;
        _car.CarDestroyed -= OnCarDestroyed;
    }

    private void CarReachedEndChunk(EndChunk endChunk)
    {
        _stateSwitcher.SwitchState<GameLevelEndState>();
    }

    private void OnCarDestroyed()
    {
        _stateSwitcher.SwitchState<GameLoseState>();
    }
}
