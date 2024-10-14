using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class GameBehaviorStateSwitcher : GameBehavior, IStateSwitcher
{
    [SerializeField] private List<State> _allStates;

    private State _currentState;

    public void SwitchState<T>() where T : State
    {
        var state = _allStates.FirstOrDefault(s => s is T);
        if (state == null) Debug.LogError($"State of type {typeof(T).Name} not found in _allStates list. Make sure the state is added and initialized properly.");
        if (_currentState != null) _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }
}
