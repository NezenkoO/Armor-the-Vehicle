using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class KeyBoardInput : MonoBehaviour
{
    public float Horizontal { get; private set; }

    private void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
    }
}
