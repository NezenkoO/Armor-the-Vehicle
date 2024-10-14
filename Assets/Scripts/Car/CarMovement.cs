using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float waveAmplitude = 1f;
    [SerializeField] private float waveFrequency = 1f;
    [SerializeField] private Rigidbody _rigidbody;

    private float elapsedTime = 0f;
    private Vector3 previousPosition;
    private Vector3 initialPosition;

    private void OnEnable()
    {
        previousPosition = transform.position;
        initialPosition = transform.position;
    }

    void FixedUpdate()
    {
        elapsedTime += Time.fixedDeltaTime;

        float xOffset = Mathf.Sin(elapsedTime * waveFrequency) * waveAmplitude;
        Vector3 newPosition = new Vector3(initialPosition.x + xOffset, _rigidbody.position.y, _rigidbody.position.z + speed * Time.fixedDeltaTime);

        _rigidbody.MovePosition(newPosition);

        Vector3 direction = newPosition - previousPosition;
        if (direction != Vector3.zero)
        {
            _rigidbody.MoveRotation(Quaternion.LookRotation(direction));
        }

        previousPosition = newPosition;
    }
}
