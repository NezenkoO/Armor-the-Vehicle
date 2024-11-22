using GamePlay.Enemy;
using UnityEngine;

public class ZombieMovement : EnemyMovement
{
    public override void Run(Vector3 to)
    {
        Vector3 direction = (to - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, RotationSpeed * Time.deltaTime);
        transform.position += transform.forward * Speed * Time.deltaTime;
    }
}