using UnityEngine;

[CreateAssetMenu]
public class ZombieViewContent : ScriptableObject
{
    [SerializeField] private ParticleSystem _damageEffectParticleSystem;
    [SerializeField] private ParticleSystem _dieEffectParticleSystem;

    public void PlayDamageEffect(Vector3 position)
    {
        var instance = Instantiate(_damageEffectParticleSystem);
        instance.Play();
        Destroy(instance.gameObject, instance.main.duration);
    }

    public void PlayDieEffect(Vector3 position)
    {
        var instance = Instantiate(_dieEffectParticleSystem);
        instance.transform.position = position;
        instance.Play();
        Destroy(instance.gameObject, instance.main.duration);
    }
}