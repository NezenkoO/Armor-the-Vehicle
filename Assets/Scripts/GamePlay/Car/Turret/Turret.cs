using UnityEngine;

namespace GamePlay
{
    public class Turret : MonoBehaviour
    {
        [SerializeField] private Vector3 _defaultRotation;

        public void ResetRotation()
        {
            transform.rotation = Quaternion.Euler(_defaultRotation);
        }
    }
}