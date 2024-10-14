using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CarView : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private float _flashDuration;

    public void PlayHitAnimation()
    {
        StartCoroutine(FlashEffect());
    }

    private IEnumerator FlashEffect()
    {
        _renderer.material.SetFloat("_FlashAmount", 1);
        yield return new WaitForSeconds(_flashDuration);
        _renderer.material.SetFloat("_FlashAmount", 0);
    }
}
