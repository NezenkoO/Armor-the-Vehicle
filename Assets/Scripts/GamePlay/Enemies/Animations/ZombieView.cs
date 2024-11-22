using System.Collections;
using UnityEngine;
using Zenject;

namespace GamePlay.Enemy
{
    public class ZombieView : EnemyView
    {
        private static readonly int FlashAmount = Shader.PropertyToID("_FlashAmount");
        private static readonly string Damage = nameof(Damage);

        [SerializeField] private Renderer _renderer;
        [SerializeField] private Animator _animator;
        [SerializeField] private float _flashDuration;
        [Inject] private ZombieViewContent _zombieViewContent;

        public override void ApplyDamage(float value)
        {
            _animator.SetTrigger(Damage);
            StartCoroutine(TriggerFlashEffect());
        }

        public override void Die()
        {
            _zombieViewContent.PlayDieEffect(transform.position);
        }

        private IEnumerator TriggerFlashEffect()
        {
            _renderer.material.SetFloat(FlashAmount, 1);
            yield return new WaitForSeconds(_flashDuration);
            _renderer.material.SetFloat(FlashAmount, 0);
        }
    }
}
