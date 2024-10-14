using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class GameLoseState : State
{
    [SerializeField] private Car _car;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private CameraStateSwitcher _cameraSwitcher;
    [SerializeField] private Button _restartButton;

    private void OnEnable()
    {
        _car.SwitchState<CarDestroyedState>();
        _cameraSwitcher.SwitchState<CameraOrbitViewState>();
        _restartButton.gameObject.SetActive(true);
        _restartButton.onClick.AddListener(OnRestartButtonClick);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        if(_restartButton != null) _restartButton.gameObject.SetActive(false);
    }

    private void OnRestartButtonClick()
    {
        _stateSwitcher.SwitchState<GameSetupState>();
    }
}
