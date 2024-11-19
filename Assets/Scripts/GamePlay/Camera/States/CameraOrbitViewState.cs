using Core.State;
using UnityEngine;

namespace GamePlay
{
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
}
