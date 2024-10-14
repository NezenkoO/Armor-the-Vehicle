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
    [SerializeField] private LoseView _loseView;

    private void OnEnable()
    {
        _car.SwitchState<CarDestroyedState>();
        _cameraSwitcher.SwitchState<CameraOrbitViewState>();
        _loseView.Show();
        _loseView.OnRestartButtonClicked += OnRestartButtonClick;
    }

    private void OnDisable()
    {
        _loseView.OnRestartButtonClicked -= OnRestartButtonClick;
        _loseView.Hide();
    }

    private void OnRestartButtonClick()
    {
        _stateSwitcher.SwitchState<GameSetupState>();
    }
}
