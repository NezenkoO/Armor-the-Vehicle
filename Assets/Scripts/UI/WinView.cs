﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class WinView : MonoBehaviour
{
    public event Action OnRestartButtonClicked;

    [SerializeField] private Button _button;
    [SerializeField] private CanvasGroup _canvasGroup;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        OnRestartButtonClicked?.Invoke();
    }

    public void Show()
    {
        _canvasGroup.Show();
    }

    public void Hide()
    {
        _canvasGroup.Hide();
    }
}
