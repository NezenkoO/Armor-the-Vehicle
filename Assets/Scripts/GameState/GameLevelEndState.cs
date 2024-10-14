using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class GameLevelEndState : State
{
    [SerializeField] private CameraStateSwitcher _cameraStateSwitcher;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private Car _car;
    [SerializeField] private WinView _winView;

    private void OnEnable()
    {
        _enemySpawner.Clear();
        _cameraStateSwitcher.SwitchState<CameraOrbitViewState>();
        _car.SwitchState<CarInactiveState>();
        _winView.Show();
        _winView.OnRestartButtonClicked += OnRestartButtonClick;
    }

    private void OnDisable()
    {
        _winView.OnRestartButtonClicked -= OnRestartButtonClick;
        _winView.Hide();
    }

    private void OnRestartButtonClick()
    {
        _stateSwitcher.SwitchState<GameSetupState>();
    }
}
