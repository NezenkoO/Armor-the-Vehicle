using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Slider _slider;

    public void Initialize(float health)
    {
        _slider.maxValue = health;
        _slider.value = health;
    }

    public void ChangeHealth(float health)
    {
        _slider.value = health;
    }

    public void Hide()
    {
        _canvasGroup.Hide();
    }

    public void Show()
    {
        _canvasGroup.Show();
    }
}
