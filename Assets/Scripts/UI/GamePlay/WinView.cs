using System;
using UnityEngine;
using UnityEngine.UI;
using Utils.Extensions;

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
