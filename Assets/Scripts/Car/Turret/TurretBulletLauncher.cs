using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class TurretBulletLauncher : MonoBehaviour, IPauseHandler
{
    [SerializeField] private Transform _launcPoint;
    [SerializeField] private ProjectileObjectPoolHolder _projectileFactory;
    [SerializeField] private float _coolDown;

    private GameBehaviorCollection _projectileGameBehaviorCollection = new GameBehaviorCollection();
    private float time;

    private void Update()
    {
        _projectileGameBehaviorCollection.GameUpdate();

        time += Time.deltaTime;
        if(time >= _coolDown)
        {
            time = 0;
            Launch();
        }
    }

    private void Launch()
    {
        var bullet = _projectileFactory.Pool.Get();
        bullet.transform.position = _launcPoint.position;
        bullet.Launch(transform.up * -1);
        _projectileGameBehaviorCollection.Add(bullet);
    }

    public void SetPaused(bool isPaused)
    {
        _projectileGameBehaviorCollection.SetPaused(isPaused);
    }

    public void Clear()
    {
        _projectileGameBehaviorCollection.Clear();
    }
}
