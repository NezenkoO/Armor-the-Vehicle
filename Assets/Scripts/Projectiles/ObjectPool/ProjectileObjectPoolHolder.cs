using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ProjectileObjectPoolHolder : MonoBehaviour
{
    [SerializeField] private ProjectileFactory _factory;
    [SerializeField] private ProjectileType _type;
    [SerializeField] private int _initialSize;

    public ProjectileObjectPool Pool { get; private set; }

    private void Start()
    {
        Pool = new ProjectileObjectPool(_factory, _type, _initialSize);   
    }
}
