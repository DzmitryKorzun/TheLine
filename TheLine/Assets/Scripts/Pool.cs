using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private PoolObject _prefab;
    [SerializeField] private Transform _container;
    [SerializeField] private int _minCapacity = 10;
    [SerializeField] private int _maxCapacity = 30;
    [SerializeField] private List<PoolObject> _myPool;
    [SerializeField] private bool _autoExpand;

    private void Start()
    {
        CreatePool(); 
    }


    private void OnValidate()
    {
        if (_autoExpand)
        {
            _maxCapacity = Int32.MaxValue;
        }
    }

    private void CreatePool()
    {
        _myPool = new List<PoolObject>(_minCapacity);

        for (int i = 0; i < _minCapacity; i++)
        {
            CreateNewElement();
        }
    }

    private PoolObject CreateNewElement(bool isActive = false)
    {
        var newObj = Instantiate(_prefab, _container);
        newObj.gameObject.SetActive(isActive);
        _myPool.Add(newObj);
        return newObj;
    }

    public bool TryGetElement(out PoolObject el)
    {
        foreach (var item in _myPool)
        {
            if (!item.gameObject.activeInHierarchy)
            {
                el = item;
                item.gameObject.SetActive(true);
                return true;
            }
        }
        el = null;
        return false;
    }

    public PoolObject GetFreeElement()
    {
        if (TryGetElement(out var el))
        {
            return el;
        }

        if (_autoExpand)
        {
            return CreateNewElement(true);
        }

        if (_myPool.Count <_maxCapacity)
        {
            return CreateNewElement(true);
        }

        throw new Exception("No empty Element :-(");
    }

    public PoolObject GetFreeElement(Vector3 position)
    {
        if (TryGetElement(out var el))
        {
            return el;
        }

        if (_autoExpand)
        {
            return CreateNewElement(true);
        }

        throw new Exception("No empty Element :-(");
    }


}
