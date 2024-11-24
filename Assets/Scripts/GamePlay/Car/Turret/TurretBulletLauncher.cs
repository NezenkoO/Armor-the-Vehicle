using UnityEngine;

namespace GamePlay
{
    public class TurretBulletLauncher : MonoBehaviour
    {
        //[SerializeField] private Transform _launcPoint;
        //[SerializeField] private ProjectileObjectPool _bulletProjectileObjectPool;
        //[SerializeField] private float _coolDown;

        //private float time;

        //private void Update()
        //{
        //    time += Time.deltaTime;
        //    if (time >= _coolDown)
        //    {
        //        time = 0;
        //        Launch();
        //    }
        //}

        //private void Launch()
        //{
        //    var bullet = _bulletProjectileObjectPool.Get();
        //    bullet.transform.position = _launcPoint.position;
        //    bullet.Launch(transform.up * -1);
        //}

        //public void Clear()
        //{
        //    _bulletProjectileObjectPool.Clear();
        //}
    }
}