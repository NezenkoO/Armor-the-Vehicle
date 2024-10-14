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
    [SerializeField] private Button _restartButton;

    private void OnEnable()
    {
        _enemySpawner.Clear();
        _cameraStateSwitcher.SwitchState<CameraOrbitViewState>();
        _car.SwitchState<CarInactiveState>();
        _restartButton.gameObject.SetActive(true);
        _restartButton.onClick.AddListener(OnRestartButtonClick);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _restartButton.gameObject.SetActive(false);
    }

    private void OnRestartButtonClick()
    {
        _stateSwitcher.SwitchState<GameSetupState>();
    }
}
