﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameBehaviorCollection : IPauseHandler, IEnumerable<GameBehavior>
{
    private List<GameBehavior> _behaviors = new();

    public bool IsEmpty => _behaviors.Count == 0;

    public void Add(GameBehavior behavior)
    {
        _behaviors.Add(behavior);
    }

    public GameBehavior this[int index]
    {
        get => _behaviors[index];
        set => _behaviors[index] = value;
    }

    public void GameUpdate()
    {
        for (var i = 0; i < _behaviors.Count; i++)
        {
            if (_behaviors[i] == null || _behaviors[i].GameUpdate() == false)
            {
                var lastIndex = _behaviors.Count - 1;
                _behaviors[i] = _behaviors[lastIndex];
                _behaviors.RemoveAt(lastIndex);
                i -= 1;
            }
        }
    }

    public void Clear()
    {
        for (var i = 0; i < _behaviors.Count; i++)
        {
            _behaviors[i].Recycle();
        }
        _behaviors.Clear();
    }

    public void SetPaused(bool isPaused)
    {
        for (var i = 0; i < _behaviors.Count; i++)
        {
            _behaviors[i].SetPaused(isPaused);
        }
    }

    public IEnumerator<GameBehavior> GetEnumerator()
    {
        return _behaviors.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
