using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    protected List<T> _pool = new List<T>();
    protected int _initialSize;
    protected Func<T> _createObject;

    public ObjectPool(Func<T> createObject, int initialSize)
    {
        _initialSize = initialSize;
        _createObject = createObject;
    }

    public void Initialize()
    {
        for (int i = 0; i < _initialSize; i++)
        {
            AddObjectToPool();
        }
    }

    protected virtual T AddObjectToPool()
    {
        T obj = _createObject();
        obj.gameObject.SetActive(false);
        _pool.Add(obj);
        return obj;
    }

    public virtual T Get()
    {
        var obj = _pool.FirstOrDefault(obj => obj.gameObject.activeSelf == false);

        if(obj == null)
            obj = AddObjectToPool();

        obj.gameObject.SetActive(true);
        return obj;
    }

    public void Reclaim(T obj)
    {
        obj.gameObject.SetActive(false);
        _pool.Add(obj);
    }
}
