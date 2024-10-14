using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class CarHud : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public void Initialize(float health)
    {
        _slider.maxValue = health;
        _slider.value = health;
        _slider.gameObject.SetActive(false);
    }

    public void ChangeHealth(float health)
    {
        _slider.gameObject.SetActive(true);
        _slider.value = health;
    }

    public void Hide()
    {
        _slider.gameObject.SetActive(false);
    }
}
