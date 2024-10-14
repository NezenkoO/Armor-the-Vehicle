using System.Collections;
using UnityEngine;

public class ZombieView : EnemyView
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _flashDuration;

    public override void StartIdleAnimation()
    {
        _renderer.material.SetFloat("_FlashAmount", 0);
        _animator.SetBool("IsRunning", false);
    }

    public override void StartRunAnimation()
    {
        _animator.SetBool("IsRunning", true);
    }

    public override void StopRunAnimation()
    {
        _animator.SetBool("IsRunning", false);
    }

    public override void TakeDamageAnimation()
    {
        _animator.SetTrigger("Damage");
        StartCoroutine(FlashEffect());
    }

    private IEnumerator FlashEffect()
    {
        _renderer.material.SetFloat("_FlashAmount", 1);
        yield return new WaitForSeconds(_flashDuration);
        _renderer.material.SetFloat("_FlashAmount", 0);
    }
}
