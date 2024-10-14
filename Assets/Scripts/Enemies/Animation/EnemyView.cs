using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class EnemyView : MonoBehaviour
{
    public abstract void TakeDamageAnimation();
    public abstract void StartIdleAnimation();
    public abstract void StartRunAnimation();
    public abstract void StopRunAnimation();
}
