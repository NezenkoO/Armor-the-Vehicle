using UnityEngine;

namespace GamePlay
{
    public class TurretMovement : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed = 100f;
        [SerializeField] private KeyBoardInput _keyBoardInput;

        private void Update()
        {
            transform.Rotate(Vector3.forward, _keyBoardInput.Horizontal * _rotationSpeed * Time.deltaTime);
        }
    }
}