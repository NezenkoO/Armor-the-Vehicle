using System;
using UnityEngine;
using UnityEngine.UI;
using Utils.Extensions;

public class SetupView : MonoBehaviour
{
    public event Action GoButtonClicked;

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
        GoButtonClicked?.Invoke();
    }

    public void Show()
    {
        _canvasGroup.Show();
    }

    public void Hide()
    {
        if (_canvasGroup == null) return;
        _canvasGroup.Hide();
    }
}