using UnityEngine;
using UnityEngine.UI;
using Utils.Extensions;

namespace Core.UI
{
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
}
