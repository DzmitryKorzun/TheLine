using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class LevelGenerator : MonoBehaviour
{
    [Inject]
    private Pool _pool;
    private Camera cam;
    private 


    private void Awake()
    {
        cam = Camera.main;

    }


    void Start()
    {
        _pool.GetFreeElement();
    }




    private void AddNewRowOfMap()
    {

    }

    private void DisplacementGridGeneration()
    {

    }


}
