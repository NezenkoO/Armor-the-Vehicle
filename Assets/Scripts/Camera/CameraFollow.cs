using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset, _rotationOffset;
    [SerializeField] private float _transitionDuration = 2f;

    private Coroutine _offsetChangeCoroutine, _rotationChangeCoroutine;

    private void OnValidate()
    {
        if (_target == null)
            return;

        LateUpdate();
    }

    private void LateUpdate()
    {
        Quaternion rotation = Quaternion.Euler(_rotationOffset);
        Vector3 rotatedOffset = rotation * _offset;

        transform.position = _target.position + rotatedOffset;
        transform.LookAt(_target);
    }

    public void SetOffset(Vector3 offset)
    {
        if (_offsetChangeCoroutine != null) StopCoroutine(_offsetChangeCoroutine);
        _offset = offset;
    }

    public void SetOffsetAnimated(Vector3 newOffset)
    {
        if (_offsetChangeCoroutine != null) StopCoroutine(_offsetChangeCoroutine);
        _offsetChangeCoroutine = StartCoroutine(AnimateOffsetChange(newOffset));
    }

    public void SetRotationOffset(Vector3 rotationOffset)
    {
        _rotationOffset = rotationOffset;
    }

    public void SetRotationOffsetAnimated(Vector3 newRotationOffset)
    {
        if (_rotationChangeCoroutine != null) StopCoroutine(_rotationChangeCoroutine);
        _rotationChangeCoroutine = StartCoroutine(AnimateRotationChange(newRotationOffset));
    }

    private IEnumerator AnimateOffsetChange(Vector3 newOffset)
    {
        Vector3 initialOffset = _offset;
        float elapsedTime = 0f;

        while (elapsedTime < _transitionDuration)
        {
            elapsedTime += Time.deltaTime;
            _offset = Vector3.Lerp(initialOffset, newOffset, elapsedTime / _transitionDuration);
            yield return null;
        }

        _offset = newOffset;
    }

    private IEnumerator AnimateRotationChange(Vector3 newRotationOffset)
    {
        Vector3 initialRotationOffset = _rotationOffset;
        float elapsedTime = 0f;

        while (elapsedTime < _transitionDuration)
        {
            elapsedTime += Time.deltaTime;
            _rotationOffset = Vector3.Lerp(initialRotationOffset, newRotationOffset, elapsedTime / _transitionDuration);
            yield return null;
        }

        _rotationOffset = newRotationOffset;
    }
}
