using Core.State;
using UnityEngine;

namespace GamePlay
{
    public class SideCameraViewState : State
    {
        [SerializeField] private CameraFollow _cameraFollow;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private Vector3 _rotationOffset;

        private void OnEnable()
        {
            _cameraFollow.enabled = true;
            _cameraFollow.SetOffset(_offset);
            _cameraFollow.SetRotationOffset(_rotationOffset);
        }

        private void OnDisable()
        {
            _cameraFollow.enabled = false;
        }
    }
}
