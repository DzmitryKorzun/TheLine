using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class LevelGenerator : MonoBehaviour
{
    [Inject]
    private Pool _pool;
    void Start()
    {
        _pool.GetFreeElement();
    }


    void Update()
    {
        
    }
}
