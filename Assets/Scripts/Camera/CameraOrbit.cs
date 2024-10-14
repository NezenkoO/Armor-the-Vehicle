using System.Collections;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _rotationSpeed = 20f;
    [SerializeField] private float _distance = 5f;
    [SerializeField] private Vector3 _offset = Vector3.up;
    [SerializeField] private float _smoothTime = 0.3f;

    private Vector3 _currentVelocity = Vector3.zero;
    private float _currentAngle = 180f;

    private void LateUpdate()
    {
        if (_target == null)
            return;

        _currentAngle += _rotationSpeed * Time.deltaTime;
        if (_currentAngle >= 360f) _currentAngle -= 360f;

        Vector3 desiredPosition = new Vector3(
            Mathf.Sin(_currentAngle) * _distance,
            _offset.y,
            Mathf.Cos(_currentAngle) * _distance
        );

        Vector3 targetPosition = _target.position + desiredPosition;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, _smoothTime);

        transform.LookAt(_target);
    }
}
