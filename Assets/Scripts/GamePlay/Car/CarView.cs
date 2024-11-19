using System.Collections;
using UnityEngine;

namespace GamePlay
{
    public class CarView : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;
        [SerializeField] private float _flashDuration;

        private static readonly int _flashAmount = Shader.PropertyToID("_FlashAmount");

        public void PlayHitAnimation()
        {
            StartCoroutine(FlashEffect());
        }

        private IEnumerator FlashEffect()
        {
            _renderer.material.SetFloat(_flashAmount, 1);
            yield return new WaitForSeconds(_flashDuration);
            _renderer.material.SetFloat(_flashAmount, 0);
        }
    }
}