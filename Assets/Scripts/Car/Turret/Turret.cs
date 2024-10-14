using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Vector3 _defaultRotation;

    public void ResetRotation()
    {
        transform.rotation = Quaternion.Euler(_defaultRotation);
    }
}
