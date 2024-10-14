using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CameraOrbitViewState : State
{
    [SerializeField] private CameraOrbit _cameraOrbit;

    private void OnEnable()
    {
        _cameraOrbit.enabled = true;
    }

    private void OnDisable()
    {
        _cameraOrbit.enabled = false;
    }
}
